using AutoMapper;
using Library.Application.Commands.GenreCommands.CreateCommand;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.API.Models.GenreModels
{
    public class CreateGenreDTO : IMapWith<CreateGenreCommand>
    {
  
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGenreDTO, CreateGenreCommand>()
                .ForMember(createGenreDTO => createGenreDTO.Name,
                    opt => opt.MapFrom(genreCommand => genreCommand.Name));

        }
    }
}
