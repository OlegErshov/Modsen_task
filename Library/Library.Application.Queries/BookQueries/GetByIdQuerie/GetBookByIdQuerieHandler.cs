using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetByIdQuerie
{
    public class GetBookByIdQuerieHandler : IRequestHandler<GetBookByIdQuerie, Book>
    {
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        public Task<Book> Handle(GetBookByIdQuerie request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
