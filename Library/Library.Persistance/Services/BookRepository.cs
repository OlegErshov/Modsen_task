using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Library.Persistance.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly IAppDbContext _context;

        public BookRepository(IAppDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Book entity, CancellationToken cancellationToken)
        {
            await _context.Books.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Book entity,CancellationToken cancellationToken)
        {

            _context.Books.Remove(entity);
            var deletedRows = await _context.SaveChangesAsync(cancellationToken);
            return deletedRows > 0;
        }

        public async Task<Book> GetBookByISBN(string isbn,CancellationToken cancellationToken)
        {
            IQueryable<Book>? query = _context.Books.AsQueryable();
            query = query.Where(el => el.ISBN == isbn);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            IQueryable<Book>? query = _context.Books.AsQueryable();

            query = query.Where(el => el.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetListAsync(CancellationToken cancellationToken)
        {
           return await _context.Books.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Book entity,CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(entity.Id);

            if(book is null)
            {
                return false;
            }
            updateBook(book,entity);

            var updatedRows = await _context.SaveChangesAsync(cancellationToken);
            return updatedRows > 0;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Books.FirstOrDefaultAsync(filter, cancellationToken);
        }

        private static void updateBook(Book book, Book newBook)
        {
            book.Id = newBook.Id;
            book.Title = newBook.Title;
            book.AuthorId = newBook.AuthorId;
            book.ISBN = newBook.ISBN;
            book.ReturnDate = newBook.ReturnDate;
            book.RecieveDate = newBook.RecieveDate;
            book.GenreId = newBook.GenreId;
        }
    }
}
