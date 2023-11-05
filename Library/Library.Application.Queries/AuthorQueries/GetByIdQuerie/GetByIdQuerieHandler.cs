using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class GetByIdQuerieHandler : IRequestHandler<GetByIdQuerie, Author>
    {

        private readonly ILogger<GetByIdQuerieHandler> _logger;
        private readonly IAuthorRepository _authorRepository;

        public GetByIdQuerieHandler(ILogger<GetByIdQuerieHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetByIdQuerie request, CancellationToken cancellationToken)
        {
             var author = await _authorRepository.GetByIdAsync(request.id, cancellationToken).Result;

            _logger.LogInformation(author is not null
               ? $"Post {request.id} has been retrieved from db"
               : $"Failed to get post {request.id}");

            return author;
        }
    }
}
