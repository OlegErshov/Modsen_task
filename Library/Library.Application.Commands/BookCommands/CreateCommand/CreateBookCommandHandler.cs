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

namespace Library.Application.Commands.BookCommands.CreateCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(ILogger<CreateAuthorCommandHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var Id = Guid.NewGuid();

            var book = new Book(Id, request.Title, request.ISBN, request.Description, request.RecieveDate, request.ReturnDate,
                                request.Author, request.Genre);
            await _bookRepository.AddAsync(book, cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Book {book.Id} has been saved to db");
            return Unit.Value;
        }
    }
}
