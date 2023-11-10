using AutoMapper;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.Models;
using Library.Application.Commands.BookCommands.UpdateCommand;
using Library.Domain.Mapping;

namespace Library.API.Models.BookModels
{
    public class UpdateBookDTO : IMapWith<UpdateBookCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDTO, UpdateBookCommand>()
                .ForMember(updateBookDto => updateBookDto.Title,
                    opt => opt.MapFrom(bookCommand => bookCommand.Title))
                .ForMember(updateBookDto => updateBookDto.ISBN,
                    opt => opt.MapFrom(bookCommand => bookCommand.ISBN))
                .ForMember(updateBookDto => updateBookDto.Description,
                    opt => opt.MapFrom(bookCommand => bookCommand.Description))
                .ForMember(updateBookDto => updateBookDto.RecieveDate,
                    opt => opt.MapFrom(bookCommand => bookCommand.RecieveDate))
                .ForMember(updateBookDto => updateBookDto.ReturnDate,
                    opt => opt.MapFrom(bookCommand => bookCommand.ReturnDate))
                .ForMember(updateBookDto => updateBookDto.AuthorReply,
                    opt => opt.MapFrom(bookCommand => bookCommand.AuthorReply))
                .ForMember(updateBookDto => updateBookDto.GenreReply,
                    opt => opt.MapFrom(bookCommand => bookCommand.GenreReply));
        }
    }
}
