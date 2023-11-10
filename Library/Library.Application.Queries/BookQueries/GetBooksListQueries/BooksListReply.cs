using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class BooksListReply 
    {   
        public IList<BooksListDTO> Books { get; set; }
    }
}
