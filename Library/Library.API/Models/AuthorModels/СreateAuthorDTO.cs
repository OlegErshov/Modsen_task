using AutoMapper;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;

namespace Library.API.Models.AuthorModels
{
    public class СreateAuthorDTO : IMapWith<CreateAuthorCommand>
    {
        public string FirstName { get;  set; }
        public string Surname { get;  set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<СreateAuthorDTO, CreateAuthorCommand>()
                .ForMember(createAuthorDTO => createAuthorDTO.FirstName,
                    opt => opt.MapFrom(authorCommand => authorCommand.FirstName))
                .ForMember(createAuthorDTO => createAuthorDTO.Surname,
                    opt => opt.MapFrom(authorCommand => authorCommand.Surname));
        }
    }
}
