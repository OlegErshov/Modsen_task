﻿// <auto-generated />
using System;
using Library.Persistance.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231112210711_final_db_fersion")]
    partial class final_db_fersion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d836356-e43b-421d-985e-add2a4b341db"),
                            FirstName = "Stiven",
                            Surname = "King"
                        },
                        new
                        {
                            Id = new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"),
                            FirstName = "Dmitriy",
                            Surname = "Emec"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("authorId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid")
                        .HasColumnName("genreId");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("RecieveDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ISBN")
                        .IsUnique();

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("295dbecc-3bac-4b46-934a-1b4dabdab24e"),
                            AuthorId = new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"),
                            Description = "Cool book about romance, fighting and fascinating turning points in plot",
                            GenreId = new Guid("90e31958-2608-4563-adb9-20bd73833033"),
                            ISBN = "978-5-699-91155-4",
                            RecieveDate = new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2970),
                            ReturnDate = new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2980),
                            Title = "Valkuries Revenge"
                        },
                        new
                        {
                            Id = new Guid("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"),
                            AuthorId = new Guid("5d836356-e43b-421d-985e-add2a4b341db"),
                            Description = "Great book from a great author",
                            GenreId = new Guid("90e31958-2608-4563-adb9-20bd73833033"),
                            ISBN = "133-7-657-91110-7",
                            RecieveDate = new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2984),
                            ReturnDate = new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2985),
                            Title = "Dark Tower"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aafe849b-ac4f-4075-8700-7f315ef1c7d1"),
                            Name = "Detective"
                        },
                        new
                        {
                            Id = new Guid("90e31958-2608-4563-adb9-20bd73833033"),
                            Name = "Fiction"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Library.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
