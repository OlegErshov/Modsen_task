using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetBooksListAsync(CancellationToken cancellationToken);
        Task CreateBook(Book book, CancellationToken cancellationToken);
        Task UpdateBookAsync(int id, Book book, CancellationToken cancellationToken);
        Task DeleteBooknAsync(int id);
    }
}
