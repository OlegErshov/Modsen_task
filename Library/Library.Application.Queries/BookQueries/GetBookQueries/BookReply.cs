using AutoMapper;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
using Library.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries.GetBookQueries
{
    public class BookReply : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorReply>();
        }
    }
}
