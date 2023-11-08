using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetByIdQuerie
{
    public class GetGenreByIdQuerieHandler : IRequestHandler<GetGenreByIdQuerie, GenreDTO>
    {
        private readonly ILogger<GetGenreByIdQuerieHandler> _logger;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenreByIdQuerieHandler(ILogger<GetGenreByIdQuerieHandler> logger, IGenreRepository authorRepository, IMapper mapper)
        {
            _logger = logger;
            _genreRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<GenreDTO> Handle(GetGenreByIdQuerie request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Id, cancellationToken);

            _logger.LogInformation(genre is not null
               ? $"Genre {request.Id} has been retrieved from db"
               : $"Failed to get genre {request.Id}");

            return _mapper.Map<GenreDTO>(genre);
        }
    }
}
