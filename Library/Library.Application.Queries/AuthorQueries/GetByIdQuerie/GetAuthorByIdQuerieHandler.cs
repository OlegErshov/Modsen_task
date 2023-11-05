using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class GetAuthorByIdQuerieHandler : IRequestHandler<GetAuthorByIdQuerie, Author>
    {

        private readonly ILogger<GetAuthorByIdQuerieHandler> _logger;
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdQuerieHandler(ILogger<GetAuthorByIdQuerieHandler> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuerie request, CancellationToken cancellationToken)
        {
             var author = await _authorRepository.GetByIdAsync(request.id, cancellationToken);

            _logger.LogInformation(author is not null
               ? $"Post {request.id} has been retrieved from db"
               : $"Failed to get post {request.id}");

            return author;
        }
    }
}
