using Library.Application.Commands.BookCommands.Models;
using MediatR;

namespace Library.Application.Commands.BookCommands.CreateCommand
{
    public class CreateBookCommand : IRequest<Unit>
    {
        public CreateBookDTO createBookDTO {  get; set; }
    }
}
