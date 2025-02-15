using MyBank.Repository.Accounts;

namespace MyBank.Services.Customers;

public class CustomerDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}