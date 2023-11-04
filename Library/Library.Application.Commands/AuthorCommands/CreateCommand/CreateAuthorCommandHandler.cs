using Library.Persistance.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.AuthorCommands.CreateCommand
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        private readonly AuthorRepository;
        public Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
