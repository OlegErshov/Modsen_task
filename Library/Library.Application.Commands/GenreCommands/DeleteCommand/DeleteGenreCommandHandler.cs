using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

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
            var deleteGenre = await _genreRepository.FirstOrDefault(genre => genre.Id == request.Id, cancellationToken);
            if (deleteGenre is null)
            {
                _logger.LogInformation($"this genre with id {request.Id} doesn't exist in db");
            }
            else
            {
                await _genreRepository.Delete(request.Id);
                await _genreRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Genre {request.Id} has been deleted from db");
            }
            return Unit.Value;
        }
    }
}
