using MyBank.Repository.Customers;
using MyBank.Repository.Enums;
using MyBank.Repository.Transactions;

namespace MyBank.Services.Accounts;

public record AccountDto
{
    public int Id { get; set; }
    public string AccountNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public AccountType AccountType { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public ICollection<Transaction>? Transactions { get; set; }
}

