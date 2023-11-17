using Library.Application.Commands.AuthorCommands.CreateCommand;
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

namespace Library.Application.Commands.BookCommands.CreateCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateBookCommandHandler(ILogger<CreateBookCommandHandler> logger, 
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var Id = Guid.NewGuid();

            var genre = await _genreRepository.FirstOrDefaultAsync(genre => genre.Name == request.createBookDTO.GenreReply.Name,
                    cancellationToken);

            if (genre is null)
            {
                _logger.LogInformation($"Genre hasn't been founded");
            }

            var author = await _authorRepository.FirstOrDefaultAsync(
                author => (author.FirstName + author.Surname) == 
                (request.createBookDTO.AuthorReply.FirstName + request.createBookDTO.AuthorReply.Surname), cancellationToken);

            if (author is null)
            {
                _logger.LogInformation($"Author hasn't been founded");
            }

            var isBookAlreadyExsist = await _bookRepository.FirstOrDefaultAsync(
               book => book.Title == request.createBookDTO.Title, cancellationToken);

            if (isBookAlreadyExsist is not null)
            {
                _logger.LogInformation($"this book with name {request.createBookDTO.Title} is already exist");
            }
            else
            {
                var book = new Book(Id, request.createBookDTO.Title, request.createBookDTO.ISBN,
                    request.createBookDTO.Description, author.Id, genre.Id);

                await _bookRepository.AddAsync(book, cancellationToken);
                await _bookRepository.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Book {book.Id} has been saved to db");
            }
            return Unit.Value;
        }
    }
}
