using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> FirstOrDefault(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken);
    }
}
