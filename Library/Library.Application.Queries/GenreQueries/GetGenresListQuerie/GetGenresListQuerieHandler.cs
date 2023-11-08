using AutoMapper;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetGenresListQuerie
{
    public class GetGenresListQuerieHandler : IRequestHandler<GetGenresListQuerie,GenresListReply>
    {
        private readonly ILogger<GetGenresListQuerieHandler> _logger;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenresListQuerieHandler(ILogger<GetGenresListQuerieHandler> logger, IGenreRepository genreRepository, IMapper mapper)
        {
            _logger = logger;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenresListReply> Handle(GetGenresListQuerie request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetListAsync(cancellationToken);

            _logger.LogInformation(genres is not null
              ? $"Genres has been retrieved from db"
              : $"Failed to get all genres from db");

            return _mapper.Map<GenresListReply>(genres);
        }
    }
}
