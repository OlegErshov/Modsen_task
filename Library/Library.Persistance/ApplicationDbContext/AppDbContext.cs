using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Persistance.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.ApplicationDbContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());

            modelBuilder.Entity<Genre>().HasData(
                     new Genre { Id = Guid.Parse("aafe849b-ac4f-4075-8700-7f315ef1c7d1"), Name = "Detective" },
                     new Genre { Id = Guid.Parse("90e31958-2608-4563-adb9-20bd73833033"), Name = "Fiction" }
                );

            modelBuilder.Entity<Author>().HasData(
                    new Author { Id = Guid.Parse("5d836356-e43b-421d-985e-add2a4b341db"), FirstName = "Stiven", Surname = "King" },
                    new Author { Id = Guid.Parse("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"), FirstName = "Dmitriy", Surname = "Emec" }
                );

            modelBuilder.Entity<Book>().HasData(

                     new Book
                     {
                         Id = Guid.Parse("295dbecc-3bac-4b46-934a-1b4dabdab24e"),
                         ISBN = "978-5-699-91155-4",
                         Title = "Valkuries Revenge",
                         Description = "Cool book about romance, fighting and fascinating turning points in plot",
                         RecieveDate = DateTime.Now,
                         ReturnDate = DateTime.Now,
                         AuthorId = Guid.Parse("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"),
                         GenreId = Guid.Parse("90e31958-2608-4563-adb9-20bd73833033")
                     },

                     new Book
                     {
                         Id = Guid.Parse("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"),
                         ISBN = "133-7-657-91110-7",
                         Title = "Dark Tower",
                         Description = "Great book from a great author",
                         RecieveDate = DateTime.Now,
                         ReturnDate = DateTime.Now,
                         AuthorId = Guid.Parse("5d836356-e43b-421d-985e-add2a4b341db"),
                         GenreId = Guid.Parse("90e31958-2608-4563-adb9-20bd73833033")
                     }
                ) ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
