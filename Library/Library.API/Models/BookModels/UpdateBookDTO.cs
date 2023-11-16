using AutoMapper;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.Models;
using Library.Application.Commands.BookCommands.UpdateCommand;


namespace Library.API.Models.BookModels
{
    public class UpdateBookDTO 
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }
    }
}
