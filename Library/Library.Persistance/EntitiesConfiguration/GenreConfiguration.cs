using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.EntitiesConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(genre => genre.Id);

            builder.Property(genre => genre.Name).IsRequired()
                                                 .HasMaxLength(100);

            builder.HasMany(genre => genre.Books)
                   .WithOne(book => book.Genre)
                   .HasForeignKey(book => book.GenreId);
        }
    }
}
