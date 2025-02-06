using System.Linq.Expressions;

namespace MyBank.Repository;

public interface IGenericRepository<T>
{
    Task<T> GetByIdAsync(int id);

    IQueryable<T> GetAll();

    IQueryable<T> Where(Expression<Func<T, bool>> expression);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}