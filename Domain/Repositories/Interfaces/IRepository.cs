using System.Linq.Expressions;

namespace Domain.Repositories.Interfaces; 

public interface IRepository<TEntitiy> where TEntitiy:class {
    Task<TEntitiy> ReadAsync(int id);

    Task<List<TEntitiy>> ReadAsync(Expression<Func<TEntitiy,bool>>filter);

    Task<List<TEntitiy>> ReadAllAsync();

    Task<List<TEntitiy>> ReadAllAsync(int start, int count);

    Task<TEntitiy> CreateAsync(TEntitiy entitiy);

    Task UpdateAsync(TEntitiy entitiy);
    
    Task DeleteAsync(TEntitiy entitiy);
}