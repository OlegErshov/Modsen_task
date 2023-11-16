using AutoMapper;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;


namespace Library.API.Models.AuthorModels
{
    public class СreateAuthorDTO 
    {
        public string FirstName { get;  set; }
        public string Surname { get;  set; }
    }
}
