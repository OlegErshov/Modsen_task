using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetByISBNQuerie
{
    public class GetBookByISBNQuerie : IRequest<Book>
    {
        public string ISBN { get; set; }
    }
}
