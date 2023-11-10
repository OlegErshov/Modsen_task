using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;
using Library.Domain.Mapping;


namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class BooksListDTO : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BooksListDTO>()
                .ForMember(bookDto => bookDto.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title, opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.Description, opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.AuthorReply, opt => opt.MapFrom(book => book.Author))
                .ForMember(bookDto => bookDto.GenreReply, opt => opt.MapFrom(book => book.Genre));
        }
    }
}
