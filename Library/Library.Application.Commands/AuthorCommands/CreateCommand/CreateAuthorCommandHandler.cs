using Library.Domain.Entities;
using Library.Domain.Interfaces;
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
        private readonly IAuthorRepository _authorRepository;
         
        public CreateAuthorCommandHandler(ILogger<CreateAuthorCommandHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }


        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            var author = new Author(id,request.FirstName,request.Surname);
            await _authorRepository.AddAsync(author,cancellationToken);
            await _authorRepository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Author {author.Id} has been saved to db");
            return Unit.Value;
        }
    }
}
