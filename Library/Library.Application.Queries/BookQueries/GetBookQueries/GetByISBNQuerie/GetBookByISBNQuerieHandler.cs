using AutoMapper;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByISBNQuerie
{
    public class GetBookByISBNQuerieHandler : IRequestHandler<GetBookByISBNQuerie, BookDTO>
    {
        private readonly ILogger<GetBookByIdQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookByISBNQuerieHandler(ILogger<GetBookByIdQuerieHandler> logger, IBookRepository bookRepository,IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByISBNQuerie request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByISBN(request.ISBN, cancellationToken);

            _logger.LogInformation(book is not null
               ? $"Book {request.ISBN} has been retrieved from db"
               : $"Failed to get book {request.ISBN}");

            return _mapper.Map<BookDTO>(book);
        }
    }
}
