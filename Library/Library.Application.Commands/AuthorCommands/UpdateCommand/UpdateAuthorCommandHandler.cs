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
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(ILogger<UpdateAuthorCommandHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var updateAuthor = await _authorRepository.FirstOrDefault(author => author.Id == request.Id, cancellationToken);
            if (updateAuthor is null)
            {
                _logger.LogInformation($"this Author with id {request.Id} doesn't exist in db");
            }
            else
            {
                var author = new Author(request.Id, request.FirstName, request.Surname);
                _authorRepository.Update(author);
                await _authorRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Author {request.Id} has been updated from db");
            }
            return Unit.Value;
        }
    }
}
