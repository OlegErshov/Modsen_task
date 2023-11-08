using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EntitiesConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);

            builder.HasIndex(book => book.ISBN).IsUnique();



            builder.Property(book => book.Title).IsRequired()
                                                .HasMaxLength(255);

            builder.Property(book => book.ISBN).IsRequired()
                                                .HasMaxLength(20);

            builder.Property(book => book.Description).IsRequired()
                                           .HasMaxLength(500);

            builder.Property(book => book.ReturnDate).HasColumnType("date");

            builder.Property(book => book.RecieveDate).HasColumnType("date");

            builder.Property(book => book.AuthorId).IsRequired()
                                                 .HasColumnName("authorId");

            builder.Property(book => book.GenreId).IsRequired()
                                                 .HasColumnName("genreId");
        }   
    }
}
