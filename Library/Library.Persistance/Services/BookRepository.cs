using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public  Task Delete(Guid id)
        {
            var book = new Book { Id = id };
            return Task.FromResult(_context.Books.Remove(book));
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

        public Book Update(Book entity)
        {
            return _context.Books.Update(entity).Entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Book> FirstOrDefault(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Books.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
