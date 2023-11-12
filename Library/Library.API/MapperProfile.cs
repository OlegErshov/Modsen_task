using AutoMapper;
using Library.API.Models.AuthorModels;
using Library.API.Models.BookModels;
using Library.API.Models.GenreModels;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Commands.AuthorCommands.UpdateCommand;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.UpdateCommand;
using Library.Application.Commands.GenreCommands.CreateCommand;
using Library.Application.Commands.GenreCommands.UpdateCommand;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Application.Queries.GenreQueries.GetGenresListQuerie;
using Library.Domain.Entities;

namespace Library.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<СreateAuthorDTO, CreateAuthorCommand>()
                .ForMember(createAuthorDTO => createAuthorDTO.FirstName,
                    opt => opt.MapFrom(authorCommand => authorCommand.FirstName))
                .ForMember(createAuthorDTO => createAuthorDTO.Surname,
                    opt => opt.MapFrom(authorCommand => authorCommand.Surname)).ReverseMap();


            CreateMap<UpdateAuthorDTO, UpdateAuthorCommand>()
                .ForMember(updateAuthorDTO => updateAuthorDTO.FirstName,
                    opt => opt.MapFrom(authorCommand => authorCommand.FirstName))
                .ForMember(updateAuthorDTO => updateAuthorDTO.Surname,
                    opt => opt.MapFrom(authorCommand => authorCommand.Surname)).ReverseMap();


            CreateMap<CreateBookDTO, CreateBookCommand>()
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.ISBN,
                    opt => opt.MapFrom(book => book.ISBN))
                .ForMember(bookDto => bookDto.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.AuthorReply,
                    opt => opt.MapFrom(book => book.AuthorReply))
                .ForMember(bookDto => bookDto.GenreReply,
                    opt => opt.MapFrom(book => book.GenreReply)).ReverseMap();



            CreateMap<UpdateBookDTO, UpdateBookCommand>()
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
                    opt => opt.MapFrom(bookCommand => bookCommand.GenreReply)).ReverseMap();


            CreateMap<CreateGenreDTO, CreateGenreCommand>()
                .ForMember(createGenreDTO => createGenreDTO.Name,
                    opt => opt.MapFrom(genreCommand => genreCommand.Name)).ReverseMap();

            CreateMap<UpdateGenreDTO, UpdateGenreCommand>()
                .ForMember(updateGenreDTO => updateGenreDTO.Name,
                    opt => opt.MapFrom(genreCommand => genreCommand.Name)).ReverseMap();
        }
    }
}
