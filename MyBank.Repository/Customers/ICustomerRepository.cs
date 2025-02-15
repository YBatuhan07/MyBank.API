namespace MyBank.Repository.Customers;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetCustomerWithAccountsAsync(int Id);
}