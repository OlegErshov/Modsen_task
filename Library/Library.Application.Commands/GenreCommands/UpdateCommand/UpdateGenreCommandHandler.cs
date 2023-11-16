using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


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
            var updateGenre = await _genreRepository.FirstOrDefault(genre => genre.Id == request.Id, cancellationToken);
            if (updateGenre is null)
            {
                _logger.LogInformation($"this genre with id {request.Id} doesn't exist in db");
            }
            else
            {
                var genre = new Genre(request.Id, request.Name);
                _genreRepository.Update(genre);
                await _genreRepository.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
