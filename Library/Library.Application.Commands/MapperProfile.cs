using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;


namespace Library.Application.Commands
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Author, AuthorReply>()
                .ForMember(authorReply => authorReply.FirstName,
                    opt => opt.MapFrom(author => author.FirstName))
                .ForMember(authorReply => authorReply.Surname,
                    opt => opt.MapFrom(author => author.Surname));


            CreateMap<Genre, GenreReply>()
                .ForMember(genreDTO => genreDTO.Name,
                    opt => opt.MapFrom(genre => genre.Name));

        }

    }
}
