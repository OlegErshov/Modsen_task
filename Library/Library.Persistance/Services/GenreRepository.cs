using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Persistance.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IAppDbContext _context;

        public GenreRepository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Genre entity, CancellationToken cancellationToken)
        {
            await _context.Genres.AddAsync(entity);
        }

        public  async Task<bool> DeleteAsync(Genre entity, CancellationToken cancellationToken)
        {
            _context.Genres.Remove(entity);
            var deletedRows = await _context.SaveChangesAsync(cancellationToken);
            return deletedRows > 0;
        }

        public async Task<Genre> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            IQueryable<Genre>? query = _context.Genres.AsQueryable();
            query = query.Where(el => el.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Genre>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Genres.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Genre entity,CancellationToken cancellationToken)
        {
            var  genre = await _context.Genres.FindAsync(entity.Id);

            if(genre is null)
            {
                return false;
            }
            genre.Name = entity.Name;

            var updatedRows = await _context.SaveChangesAsync(cancellationToken);
            return updatedRows > 0;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Genre> FirstOrDefaultAsync(Expression<Func<Genre, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Genres.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
