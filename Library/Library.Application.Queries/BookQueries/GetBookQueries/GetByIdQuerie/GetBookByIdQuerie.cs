using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie
{
    public class GetBookByIdQuerie : IRequest<BookDTO>
    {
        public Guid Id { get; set; }
    }
}
