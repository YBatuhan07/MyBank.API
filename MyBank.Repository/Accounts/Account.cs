using MyBank.Repository.Customers;
using MyBank.Repository.Enums;
using MyBank.Repository.Transactions;
using System.Text.Json.Serialization;

namespace MyBank.Repository.Accounts;

public class Account : IAuditEntity
{
    public int Id { get; set; }
    public string AccountNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public AccountType AccountType { get; set; }
    public int CustomerId { get; set; }

    [JsonIgnore]
    public Customer Customer { get; set; } = null!;

    public ICollection<Transaction>? Transactions { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}