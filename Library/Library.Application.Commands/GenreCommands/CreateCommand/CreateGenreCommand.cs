using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.GenreCommands.CreateCommand
{
    public class CreateGenreCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
