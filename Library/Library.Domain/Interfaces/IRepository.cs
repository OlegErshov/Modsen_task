using Library.Domain.Entities;
using System.Linq.Expressions;


namespace Library.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(T entity,CancellationToken cancellationToken);
        Task<bool> DeleteAsync(T entity,CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    }
}
