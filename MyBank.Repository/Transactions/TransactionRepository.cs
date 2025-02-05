namespace MyBank.Repository.Transactions;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(MyBankDbContext context) : base(context)
    {
    }
}
