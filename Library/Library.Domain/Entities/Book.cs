using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book : IEntity
    {

        public Book(Guid id, string title,string isbn, string description, DateTime receiveDate, 
                    DateTime returnDate, Author author, Genre genre) 
        { 
            Id = id;
            Title = title;
            ISBN = isbn;
            Description = description;
            RecieveDate = receiveDate;
            ReturnDate = returnDate;
            Author = author;
            Genre = genre;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }



    }
}
