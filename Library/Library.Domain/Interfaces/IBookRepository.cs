using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        public  Task<Book> GetBookByISBN(string isbn,CancellationToken cancellationToken);
    }
}
