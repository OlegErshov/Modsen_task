using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Application.Queries.GenreQueries.GetGenresListQuerie;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Persistance.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class GetBooksListQuerieHandler : IRequestHandler<GetBooksListQuerie, BooksListReply>
    {
        private readonly ILogger<GetBooksListQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetBooksListQuerieHandler(ILogger<GetBooksListQuerieHandler> logger, IBookRepository bookRepository, 
            IGenreRepository genreRepositor,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepositor;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BooksListReply> Handle(GetBooksListQuerie request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync(cancellationToken);

            IList<BooksListDTO> booksDTO = new List<BooksListDTO>();
            foreach (var item in books)
            {

                booksDTO.Add(bookMap(item,cancellationToken).Result);
            }

            _logger.LogInformation(books is not null
              ? $"Books has been retrieved from db"
            : $"Failed to get all books from db");
            return new BooksListReply { Books = booksDTO };
        }

        private async Task<BooksListDTO> bookMap(Book book,CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(book.GenreId, cancellationToken);
            if (genre is null)
            {
                _logger.LogInformation($"Genre hasn't been founded");
            }

            var author = await _authorRepository.GetByIdAsync(book.AuthorId, cancellationToken);

            if (author is null)
            {
                _logger.LogInformation($"Author hasn't been founded");
            }

            var genreReply = _mapper.Map<GenreReply>(genre);
            var authorReply = _mapper.Map<AuthorReply>(author);


            return new BooksListDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                GenreReply = genreReply,
                AuthorReply = authorReply
            };
        }
    }
}
