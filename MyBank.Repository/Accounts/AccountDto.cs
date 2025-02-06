using MyBank.Repository.Enums;

namespace MyBank.Repository.Accounts;

public class AccountDto
{
    public string AccountNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public AccountType AccountType { get; set; }
    public int CustomerId { get; set; }
}