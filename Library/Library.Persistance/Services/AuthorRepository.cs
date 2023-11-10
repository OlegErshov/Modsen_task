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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IAppDbContext _context;

        public AuthorRepository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Author entity, CancellationToken cancellationToken)
        {
            await _context.Authors.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = _context.Authors.FindAsync(id).Result;
            _context.Authors.Remove(author);
        }

        public async Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            IQueryable<Author>? query = _context.Authors.AsQueryable();

            query = query.Where(el => el.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Author>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Authors.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, Author entity, CancellationToken cancellationToken)
        {
            _context.Authors.Update(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken); 
        }

        public async Task<Author> FirstOrDefault(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Authors.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }

}
