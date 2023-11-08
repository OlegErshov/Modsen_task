using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetByIdQuerie
{
    public class GenreDTO : IMapWith<Genre>
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
