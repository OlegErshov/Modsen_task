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

        public  Task Delete(Guid id)
        {
            var genre = new Genre { Id = id };
            return Task.FromResult(_context.Genres.Remove(genre));
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

        public Genre Update(Genre entity)
        {
           return _context.Genres.Update(entity).Entity;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Genre> FirstOrDefault(Expression<Func<Genre, bool>> filter, CancellationToken cancellationToken)
        {
            return await _context.Genres.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
