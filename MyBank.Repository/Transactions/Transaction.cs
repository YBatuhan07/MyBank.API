using MyBank.Repository.Accounts;
using MyBank.Repository.Enums;

namespace MyBank.Repository.Transactions;

public class Transaction : IAuditEntity
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}