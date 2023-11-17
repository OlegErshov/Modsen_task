using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


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

        public async Task<bool> DeleteAsync(Author entity, CancellationToken cancellationToken)
        {
            _context.Authors.Remove(entity);
            var deletedRows = await _context.SaveChangesAsync(cancellationToken);
            return deletedRows > 0;
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

        public async  Task<bool> UpdateAsync(Author entity,CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FindAsync(entity.Id);

            if(author is null)
            {
                return false;
            }

            author.FirstName = entity.FirstName;
            author.Surname = entity.Surname;

            var updatedRows = await _context.SaveChangesAsync(cancellationToken);
            return updatedRows > 0;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken); 
        }

        public async Task<Author> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Authors.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
