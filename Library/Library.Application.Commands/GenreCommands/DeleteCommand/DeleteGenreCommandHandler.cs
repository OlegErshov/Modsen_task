using Library.Application.Commands.BookCommands.DeleteCommand;
using Library.Domain.Interfaces;
using Library.Persistance.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.GenreCommands.DeleteCommand
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Unit>
    {
        private readonly ILogger<DeleteGenreCommandHandler> _logger;
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreCommandHandler(ILogger<DeleteGenreCommandHandler> logger, IGenreRepository genreRepository)
        {
            _logger = logger;
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            await _genreRepository.DeleteAsync(request.Id);
            await _genreRepository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Genre {request.Id} has been deleted from db");
            return Unit.Value;
        }
    }
}
