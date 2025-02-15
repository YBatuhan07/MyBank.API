using Microsoft.EntityFrameworkCore;

namespace MyBank.Repository.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    private readonly MyBankDbContext _dbContext;

    public CustomerRepository(MyBankDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public Task<Customer?> GetCustomerWithAccountsAsync(int Id) => _context.Customers.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == Id);

}