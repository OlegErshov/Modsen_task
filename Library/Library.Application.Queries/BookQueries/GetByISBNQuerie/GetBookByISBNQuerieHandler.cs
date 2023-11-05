using Library.Application.Queries.BookQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Queries.BookQueries.GetByISBNQuerie
{
    public class GetBookByISBNQuerieHandler : IRequestHandler<GetBookByISBNQuerie, Book>
    {
        private readonly ILogger<GetBookByIdQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public GetBookByISBNQuerieHandler(ILogger<GetBookByIdQuerieHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookByISBNQuerie request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByISBN(request.ISBN,cancellationToken);

            _logger.LogInformation(book is not null
               ? $"Book {request.ISBN} has been retrieved from db"
               : $"Failed to get book {request.ISBN}");

            return book;
        }
    }
}
