using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands.UpdateCommand
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public UpdateBookDTO updateBookDTO { get; set; }
    }
}
