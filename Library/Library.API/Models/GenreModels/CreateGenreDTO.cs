using AutoMapper;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.API.Models.GenreModels
{
    public class CreateGenreDTO : IMapWith<Genre>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDTO>()
                .ForMember(genreDTO => genreDTO.Id,
                    opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreDTO => genreDTO.Name,
                    opt => opt.MapFrom(genre => genre.Name));

        }
    }
}
