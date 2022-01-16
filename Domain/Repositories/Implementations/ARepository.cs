using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations;

public abstract class ARepository<TEntity> :IRepository<TEntity> where TEntity: class {
    private TestDbContext _dbContext;
    private DbSet<TEntity> _table;

    public ARepository(TestDbContext testDbContext) {
        this._dbContext = testDbContext;
        this._table = _dbContext.Set<TEntity>();
    }
    public async Task<TEntity> ReadAsync(int id) => await _table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await _table.Where(filter).ToListAsync();


    public async Task<List<TEntity>> ReadAllAsync() => await _table.ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync(int start, int count) =>
        await _table.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entitiy) {
        _table.Add(entitiy);
        await _dbContext.SaveChangesAsync();
        return entitiy;
    }

    public async Task UpdateAsync(TEntity entitiy) {
        _table.Update(entitiy);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entitiy) {
        _table.Remove(entitiy);
        await _dbContext.SaveChangesAsync();
    }
}