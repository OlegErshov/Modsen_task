using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBookQueries.GetByISBNQuerie
{
    public class GetBookByISBNQuerie : IRequest<BookDTO>
    {
        public string ISBN { get; set; }
    }
}
