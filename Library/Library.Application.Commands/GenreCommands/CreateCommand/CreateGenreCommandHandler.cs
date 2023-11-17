using Library.Application.Commands.BookCommands.CreateCommand;
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

namespace Library.Application.Commands.GenreCommands.CreateCommand
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand,Unit>
    {
        private readonly ILogger<CreateGenreCommandHandler> _logger;
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(ILogger<CreateGenreCommandHandler> logger, IGenreRepository genreRepository)
        {
            _logger = logger;
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var Id = Guid.NewGuid();
            var genre = new Genre(Id, request.createGenreDTO.Name);
            var genreIsAlredyExist = await _genreRepository.FirstOrDefaultAsync(genre => genre.Name == request.createGenreDTO.Name, 
                cancellationToken);
            if(genreIsAlredyExist is not null)
            {
                _logger.LogInformation($"This genre with name {genre.Name} is already exist");
            }
            else
            { 
                await _genreRepository.AddAsync(genre, cancellationToken);
                await _genreRepository.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"Genre {genre.Id} has been saved to db");
            }
            return Unit.Value;
        }
    }
}
