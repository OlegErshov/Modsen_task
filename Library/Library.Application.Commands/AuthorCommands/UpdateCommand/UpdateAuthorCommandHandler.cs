using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.AuthorCommands.UpdateCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(ILogger<CreateAuthorCommandHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var author = new Author(id, request.FirstName, request.Surname);

            await _authorRepository.UpdateAsync(id, author, cancellationToken);
            await _authorRepository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Author {request.Id} has been updated from db");
            return Unit.Value;
        }
    }
}
