using AutoMapper;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


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

            IList<GenresListDTO> genresDTO = new List<GenresListDTO>();

            foreach (var item in genres)
            {
                genresDTO.Add(_mapper.Map<GenresListDTO>(item));
            }

            _logger.LogInformation(genres is not null
              ? $"Genres has been retrieved from db"
              : $"Failed to get all genres from db");

            return new GenresListReply { Genres = genresDTO };
        }
    }
}
