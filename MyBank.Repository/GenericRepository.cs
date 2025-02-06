using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MyBank.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MyBankDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MyBankDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AsQueryable().Where(expression);
    }
}