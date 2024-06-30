using Infrastructure.IRepo;
using Infrastructure1.EFDbContext;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        if (_dbSet == null) throw new Exception();
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        if (_dbSet == null) throw new Exception();
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        if (_dbSet == null) throw new Exception();
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        if (_dbSet == null) throw new Exception();
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        if (_dbSet == null) throw new Exception();
        _dbSet.Remove(entity);
    }
}