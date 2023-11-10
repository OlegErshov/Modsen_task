using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.Application.Commands.BookCommands.Models
{
    public class GenreReply : IMapWith<Genre>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreReply>()
                .ForMember(genreDTO => genreDTO.Name,
                    opt => opt.MapFrom(genre => genre.Name));

        }
    }
}
