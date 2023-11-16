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

namespace Library.Application.Commands.AuthorCommands.DeleteCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(ILogger<DeleteAuthorCommandHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var deleteAuthor = await _authorRepository.FirstOrDefault(author => author.Id == request.Id, cancellationToken);
            if (deleteAuthor is  null)
            {
                _logger.LogInformation($"this Author with id {request.Id} doesn't exist in db");
            }
            else
            {
                await _authorRepository.Delete(request.Id);
                await _authorRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Author {request.Id} has been deleted from db");
            }
            return Unit.Value;
        }

    }

    
}

       
    
