using AutoMapper;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;

namespace Library.API.Models.BookModels
{
    public class CreateBookDTO 
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }

       
    }
}
