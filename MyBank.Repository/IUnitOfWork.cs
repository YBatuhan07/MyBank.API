namespace MyBank.Repository;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
