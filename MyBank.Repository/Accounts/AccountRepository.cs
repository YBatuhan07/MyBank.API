namespace MyBank.Repository.Accounts;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(MyBankDbContext context) : base(context)
    {
    }
}