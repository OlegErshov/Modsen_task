﻿using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class GetAuthorByIdQuerieHandler : IRequestHandler<GetAuthorByIdQuerie, AuthorReply>
    {

        private readonly ILogger<GetAuthorByIdQuerieHandler> _logger;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQuerieHandler(ILogger<GetAuthorByIdQuerieHandler> logger, IAuthorRepository authorRepository, IMapper mapper)
        {
            _logger = logger;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorReply> Handle(GetAuthorByIdQuerie request, CancellationToken cancellationToken)
        {
             var author = await _authorRepository.GetByIdAsync(request.id, cancellationToken);

            _logger.LogInformation(author is not null
               ? $"Post {request.id} has been retrieved from db"
               : $"Failed to get post {request.id}");

            return _mapper.Map<AuthorReply>(author );
        }
    }
}
