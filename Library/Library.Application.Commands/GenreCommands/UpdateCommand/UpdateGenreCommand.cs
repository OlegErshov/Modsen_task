using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.GenreCommands.UpdateCommand
{
    public class UpdateGenreCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
