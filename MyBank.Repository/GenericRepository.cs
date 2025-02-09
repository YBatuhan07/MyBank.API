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
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public void Update(T entity) => _dbSet.Update(entity);

    public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbSet.Where(expression).AsNoTracking();
}