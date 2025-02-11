using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBank.Repository;
using MyBank.Repository.Accounts;
using MyBank.Services.Accounts.Create;
using MyBank.Services.Accounts.Update;
using MyBank.Services.ExceptionHandler;
using System.Globalization;
using System.Net;

namespace MyBank.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<AccountDto>>> GetAll()
    {
        throw new CriticalException("Tehlikeli hata oluştu. Sistem kesintiye uğrayabilir.");
        var result = await _accountRepository.GetAll().ToListAsync();

        #region manuel mapping

        //var accountDto = result.Select(x => new AccountDto(x.Id, x.AccountNumber, x.Balance, x.AccountType, x.CustomerId, x.Customer, x.Transactions)).ToList();

        #endregion manuel mapping

        var accountAsDto = _mapper.Map<List<AccountDto>>(result);

        return ServiceResult<List<AccountDto>>.Success(accountAsDto);
    }

    public async Task<ServiceResult<List<AccountDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        var result = await _accountRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var accountAsDto = _mapper.Map<List<AccountDto>>(result);
        return ServiceResult<List<AccountDto>>.Success(accountAsDto);
    }

    public async Task<ServiceResult<AccountDto>> GetByIdAsync(int id)
    {
        var result = await _accountRepository.GetByIdAsync(id);
        if (result is null)
        {
            return ServiceResult<AccountDto>.Fail("Account not found");
        }
        var accountAsDto = _mapper.Map<AccountDto>(result);

        return ServiceResult<AccountDto>.Success(accountAsDto);
    }

    public async Task<ServiceResult<CreateAccountResponse>> CreateAsync(CreateAccountRequest createAccountRequest)
    {
        var anyAccount = await _accountRepository.Where(x => x.AccountNumber == createAccountRequest.AccountNumber).AnyAsync();

        if (anyAccount)
        {
            return ServiceResult<CreateAccountResponse>.Fail("Ürün ismi veritabanında mevcut");
        }

        var account = new Account()
        {
            CustomerId = createAccountRequest.CustomerId,
            AccountType = createAccountRequest.AccountType,
            Balance = createAccountRequest.Balance,
            AccountNumber = createAccountRequest.AccountNumber,
        };
        await _accountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateAccountResponse>.SuccessAsCreated(new CreateAccountResponse(account.Id), $"api/accounts/{account.Id}");
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
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> UpdateBalanceAsync(UpdateAccountBalanceRequest Request)
    {
        var account = await _accountRepository.GetByIdAsync(Request.AccountId);
        if (account is null)
            return ServiceResult.Fail("Account not found", HttpStatusCode.NotFound);

        account.Balance = Request.Balance;
        _accountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
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
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}