namespace MyBank.Repository.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(MyBankDbContext context) : base(context)
    {
    }
}