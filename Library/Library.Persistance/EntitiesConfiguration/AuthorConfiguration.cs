﻿using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EntitiesConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);

            builder.Property(author => author.FirstName).IsRequired()
                                                        .HasMaxLength(100);

            builder.Property(author => author.Surname).IsRequired()
                                                      .HasMaxLength(100);

            builder.HasMany(author => author.Books)
                   .WithOne(book => book.Author)
                   .HasForeignKey(book => book.Author.Id);
        }
    }
}
