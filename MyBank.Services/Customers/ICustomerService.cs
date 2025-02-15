namespace MyBank.Services.Customers;

public interface ICustomerService
{
    Task<ServiceResult<CustomerDto>> CreateAsync(CreateCustomerRequest request);
    Task<ServiceResult<CustomerDto>> GetCustomerWithAccountsAsync(int id);
}
