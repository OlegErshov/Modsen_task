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
        private readonly ILogger<UpdateCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(ILogger<CreateAuthorCommandHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Id, request.Title, request.ISBN, request.Description, request.RecieveDate, request.ReturnDate,
                               request.Author, request.Genre);
            await _bookRepository.UpdateAsync(book.Id, book,cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
