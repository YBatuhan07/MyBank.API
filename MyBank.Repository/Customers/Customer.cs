using MyBank.Repository.Accounts;

namespace MyBank.Repository.Customers;

public class Customer : IAuditEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public ICollection<Account>? Accounts { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}