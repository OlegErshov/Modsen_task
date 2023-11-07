using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.API.Models.BookModels
{
    public class CreateBookDTO : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDTO>();
        }
    }
}
