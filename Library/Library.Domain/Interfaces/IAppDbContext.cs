using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.Domain.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
