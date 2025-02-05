
namespace MyBank.Repository;

public class UnitOfWork(MyBankDbContext context) : IUnitOfWork
{
    
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}
