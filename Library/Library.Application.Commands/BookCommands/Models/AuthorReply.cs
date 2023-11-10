using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.Application.Commands.BookCommands.Models
{
    public class AuthorReply : IMapWith<AuthorReply>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorReply>()
                .ForMember(authorReply => authorReply.FirstName,
                    opt => opt.MapFrom(author => author.FirstName))
                .ForMember(authorReply => authorReply.Surname,
                    opt => opt.MapFrom(author => author.Surname));
        }
    }
}
