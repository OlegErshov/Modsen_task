using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.GenreCommands.DeleteCommand
{
    public class DeleteGenreCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
