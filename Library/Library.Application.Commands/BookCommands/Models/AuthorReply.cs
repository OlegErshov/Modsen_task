using AutoMapper;
using Library.Domain.Entities;


namespace Library.Application.Commands.BookCommands.Models
{
    public class AuthorReply 
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
