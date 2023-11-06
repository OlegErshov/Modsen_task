using AutoMapper;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class GetBooksListQuerieHandler : IRequestHandler<GetBooksListQuerie, BooksListReply>
    {
        private readonly ILogger<GetBooksListQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksListQuerieHandler(ILogger<GetBooksListQuerieHandler> logger, IBookRepository bookRepository, IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BooksListReply> Handle(GetBooksListQuerie request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync(cancellationToken);
            
            _logger.LogInformation(books is not null
              ? $"Books has been retrieved from db"
              : $"Failed to get all books from db");

            return _mapper.Map<BooksListReply>(books);

        }
    }
}
