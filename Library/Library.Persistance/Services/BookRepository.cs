using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.Services
{
    public class BookRepository : IBookRepository<Book>
    {
        public Task AddAsync(Book entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetBookByISDN(string isdn)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Book entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
