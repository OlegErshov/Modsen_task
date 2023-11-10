using AutoMapper;
using Library.Domain.Entities;


namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class AuthorDTO 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    
    }
}
