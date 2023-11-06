using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie
{
    public class GetBookByIdQuerieHandler : IRequestHandler<GetBookByIdQuerie, BookReply>
    {
        private readonly ILogger<GetBookByIdQuerieHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQuerieHandler(ILogger<GetBookByIdQuerieHandler> logger, IBookRepository bookRepository,IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookReply> Handle(GetBookByIdQuerie request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

            _logger.LogInformation(book is not null
               ? $"Book {request.Id} has been retrieved from db"
               : $"Failed to get book {request.Id}");

            return _mapper.Map<BookReply>(book);
        }
    }
}
