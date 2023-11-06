using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class BooksListDTO : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BooksListDTO>()
                .ForMember(bookDto => bookDto.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title, opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.Author, opt => opt.MapFrom(book => book.Author))
                .ForMember(bookDto => bookDto.Genre, opt => opt.MapFrom(book => book.Genre));
        }
    }
}
