using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Application.Queries.GenreQueries.GetGenresListQuerie;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDTO>()
               .ForMember("Id",
                   opt => opt.MapFrom(author => author.Id))
               .ForMember("FirstName",
                   opt => opt.MapFrom(author => author.FirstName))
               .ForMember("Surname",
                   opt => opt.MapFrom(author => author.Surname)).ReverseMap();

            CreateMap<Genre, GenreDTO>()
                .ForMember(genreDTO => genreDTO.Id,
                    opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreDTO => genreDTO.Name,
                    opt => opt.MapFrom(genre => genre.Name));

            CreateMap<Genre, GenresListDTO>()
                .ForMember(genreDTO => genreDTO.Id,
                    opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreDTO => genreDTO.Name,
                    opt => opt.MapFrom(genre => genre.Name));

            
            CreateMap<Book, BookDTO>();

            CreateMap<Book, BooksListDTO>()
                .ForMember(bookDto => bookDto.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title, opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.Description, opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.AuthorReply, opt => opt.MapFrom(book => book.Author))
                .ForMember(bookDto => bookDto.GenreReply, opt => opt.MapFrom(book => book.Genre));
        }
    }
}
