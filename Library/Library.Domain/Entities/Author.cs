using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author : IEntity
    {

        public Author(Guid id,string firstName, string surname) 
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
        }
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } 
        public string Surname { get; private set; } 

        public ICollection<Book> Books { get; private set; } = new List<Book>();


    }
}
