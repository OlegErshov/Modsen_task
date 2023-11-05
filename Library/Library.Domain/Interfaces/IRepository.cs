using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
