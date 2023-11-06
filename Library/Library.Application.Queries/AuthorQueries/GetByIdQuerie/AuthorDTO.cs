using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class AuthorDTO : IMapWith<Author>
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDTO>()
                .ForMember(authorReply => authorReply.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorReply => authorReply.FirstName,
                    opt => opt.MapFrom(author => author.FirstName))
                .ForMember(authorReply => authorReply.Surname,
                    opt => opt.MapFrom(author => author.Surname));
        }
    }
}
