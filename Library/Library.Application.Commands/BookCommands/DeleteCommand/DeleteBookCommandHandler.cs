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

namespace Library.Application.Commands.BookCommands.DeleteCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly ILogger<DeleteBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(ILogger<DeleteBookCommandHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var deleteBook = await _bookRepository.FirstOrDefault(
                book => book.Id == request.Id, cancellationToken);
            if(deleteBook is null)
            {
                _logger.LogInformation($"Book with id: {request.Id} hasn't found");
            }
            else
            {
                await _bookRepository.Delete(request.Id);
                await _bookRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Book {request.Id} has been deleted from db");
            }
            return Unit.Value;
        }
    }
}
