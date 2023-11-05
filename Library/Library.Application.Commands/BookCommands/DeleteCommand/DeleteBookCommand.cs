using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands.DeleteCommand
{
    public class DeleteBookCommand : IRequest<Unit>
    {
         public Guid Id { get; set; }
    }
}
