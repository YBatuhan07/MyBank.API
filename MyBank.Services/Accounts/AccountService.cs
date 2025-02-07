using Microsoft.EntityFrameworkCore;
using MyBank.Repository;
using MyBank.Repository.Accounts;

namespace MyBank.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<List<AccountDto>>> GetAll()
    {
        var result = await _accountRepository.GetAll().ToListAsync();
        var accountDto = result.Select(x => new AccountDto(x.Id, x.AccountNumber, x.Balance, x.AccountType, x.CustomerId, x.Customer, x.Transactions)).ToList();

        return ServiceResult<List<AccountDto>>.Success(accountDto);
    } 
    public async Task<ServiceResult<AccountDto>> GetByIdAsync(int id)
    {
        var result = await _accountRepository.GetByIdAsync(id);
        if (result is null)
        {
            return ServiceResult<AccountDto>.Fail("Account not found");
        }
        var accountAsDto = new AccountDto(result.Id,result.AccountNumber ,result.Balance, result.AccountType, result.CustomerId, result.Customer, result.Transactions);
        
        return ServiceResult<AccountDto>.Success(accountAsDto);
    }

    public async Task<ServiceResult<CreateAccountResponse>> CreateAsync(CreateAccountRequest createAccountRequest)
    {
        var account = new Account()
        {
            CustomerId = createAccountRequest.CustomerId,
            AccountType = createAccountRequest.AccountType,
            Balance = createAccountRequest.Balance,
            AccountNumber = createAccountRequest.AccountNumber,
        };
        await _accountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateAccountResponse>.Success(new CreateAccountResponse(account.Id));
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateAccountRequest updateAccountRequest)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account is null)
        {
            return ServiceResult.Fail("Account not found", System.Net.HttpStatusCode.NotFound);
        }
        account.AccountNumber = updateAccountRequest.AccountNumber;
        account.Balance = updateAccountRequest.Balance;
        account.CustomerId = updateAccountRequest.CustomerId;
        account.AccountType = updateAccountRequest.AccountType;
        account.Id = id;

        _accountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success();
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var account = await _accountRepository.GetByIdAsync(id);

        if (account is null)
        {
            return ServiceResult.Fail("Account not found", System.Net.HttpStatusCode.NotFound);
        }

        _accountRepository.Delete(account);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success();
    }
}