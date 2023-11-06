using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class GetAuthorByIdQuerie : IRequest<AuthorReply>
    {
        public Guid id { get; set; }
    }
}
