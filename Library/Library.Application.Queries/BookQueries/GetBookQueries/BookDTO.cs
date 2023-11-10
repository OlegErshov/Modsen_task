using AutoMapper;
using Library.Application.Commands.BookCommands.Models;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBookQueries
{
    public class BookDTO 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }

       
    }
}
