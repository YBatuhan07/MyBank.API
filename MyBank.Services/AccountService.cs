using MyBank.Repository.Accounts;

namespace MyBank.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    

    public void AddAccount(AccountDto accountDto)
    {
        Account account = new Account();
        account.AccountType = accountDto.AccountType;
        account.AccountNumber = accountDto.AccountNumber;
        account.CustomerId = accountDto.CustomerId;
        account.Balance = accountDto.Balance;
        _accountRepository.AddAsync(account);
    }
}