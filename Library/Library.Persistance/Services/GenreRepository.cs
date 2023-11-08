using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task DeleteAsync(Guid id)
        {
            var genre = _context.Genres.FindAsync(id).Result;
            _context.Genres.Remove(genre);
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

        public Task UpdateAsync(Guid id, Genre entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
