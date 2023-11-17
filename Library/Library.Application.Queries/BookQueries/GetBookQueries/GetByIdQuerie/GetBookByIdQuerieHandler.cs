using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie
{
    public class GetBookByIdQuerieHandler : IRequestHandler<GetBookByIdQuerie, BookDTO>
    {
        private readonly ILogger<GetBookByIdQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQuerieHandler(ILogger<GetBookByIdQuerieHandler> logger, IBookRepository bookRepository,
            IGenreRepository genreRepository,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuerie request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

            _logger.LogInformation(book is not null
               ? $"Book {request.Id} has been retrieved from db"
               : $"Failed to get book {request.Id}");

            var genre = await _genreRepository.GetByIdAsync(book.GenreId, cancellationToken);

            if (genre is null)
            {
                _logger.LogInformation($"Genre hasn't been founded");
            }

            var author = await _authorRepository.GetByIdAsync(book.AuthorId,cancellationToken);

            if (author is null)
            {
                _logger.LogInformation($"Author hasn't been founded");
            }

            var genreReply = _mapper.Map<GenreReply>(genre);
            var authorReply = _mapper.Map<AuthorReply>(author);


            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                RecieveDate = book.RecieveDate,
                ReturnDate = book.ReturnDate,
                GenreReply = genreReply,
                AuthorReply = authorReply
            };
        }
    }
}
