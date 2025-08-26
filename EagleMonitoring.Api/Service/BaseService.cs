using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly EagleManagementContext _context;

    public BaseService(EagleManagementContext context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
            throw new InvalidOperationException($"Entity of type {typeof(T).Name} with id {id} not found.");
        return entity;
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
