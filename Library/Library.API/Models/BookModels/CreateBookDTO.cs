using AutoMapper;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.API.Models.BookModels
{
    public class CreateBookDTO : IMapWith<CreateBookCommand>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDTO, CreateBookCommand>()
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.ISBN,
                    opt => opt.MapFrom(book => book.ISBN))
                .ForMember(bookDto => bookDto.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.AuthorReply,
                    opt => opt.MapFrom(book => book.AuthorReply))
                .ForMember(bookDto => bookDto.GenreReply,
                    opt => opt.MapFrom(book => book.GenreReply));
        }
    }
}
