using Library.Application.Commands.BookCommands.UpdateCommand;
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

namespace Library.Application.Commands.GenreCommands.UpdateCommand
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand,Unit>
    {
        private readonly ILogger<UpdateGenreCommandHandler> _logger;
        private readonly IGenreRepository _genreRepository;

        public UpdateGenreCommandHandler(ILogger<UpdateGenreCommandHandler> logger, IGenreRepository genreRepository)
        {
            _logger = logger;
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre(request.Id, request.Name);
            await _genreRepository.UpdateAsync(genre.Id, genre, cancellationToken);
            await _genreRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
