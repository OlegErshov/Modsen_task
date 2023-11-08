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
                    DateTime returnDate,Guid authorId,Guid genreId, Author author, Genre genre) 
        { 
            Id = id;
            Title = title;
            ISBN = isbn;
            Description = description;
            RecieveDate = receiveDate;
            ReturnDate = returnDate;
            AuthorId = authorId;
            GenreId = genreId;
            Author = author;
            Genre = genre;
        }

        public Book(Guid id, string title, string iSBN, string description, DateTime recieveDate,
                    DateTime returnDate, Guid authorId, Guid genreId)
        {
            Id = id;
            Title = title;
            ISBN = iSBN;
            Description = description;
            RecieveDate = recieveDate;
            ReturnDate = returnDate;
            AuthorId = authorId;
            GenreId = genreId;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Guid AuthorId { get; set; }

        public Guid GenreId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }



    }
}
