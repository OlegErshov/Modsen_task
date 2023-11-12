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

namespace Library.Application.Commands.BookCommands.UpdateCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly ILogger<UpdateBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;

        public UpdateBookCommandHandler(ILogger<UpdateBookCommandHandler> logger, 
            IBookRepository bookRepository,
            IGenreRepository genreRepository,
            IAuthorRepository authorRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.FirstOrDefault(genre => genre.Name == request.GenreReply.Name,cancellationToken);

            if (genre is null) {
                _logger.LogInformation($"Genre hasn't been founded");
            }

            var author = await _authorRepository.FirstOrDefault(
                author => (author.FirstName + author.Surname) == (request.AuthorReply.FirstName + request.AuthorReply.Surname),cancellationToken);

            if (author is null)
            {
                _logger.LogInformation($"Author hasn't been founded");
            }
            

            var book = new Book(request.Id, request.Title, request.ISBN, request.Description, request.RecieveDate, request.ReturnDate,
               author.Id,genre.Id);
             
            await _bookRepository.UpdateAsync(book.Id, book,cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Book {book.Id} has been updated in db");
            return Unit.Value;
        }
    }
}
