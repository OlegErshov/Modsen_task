using Library.Application.Commands.BookCommands.Models;
using MediatR;

namespace Library.Application.Commands.BookCommands.CreateCommand
{
    public class CreateBookCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        
        public AuthorReply  AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }
    }
}
