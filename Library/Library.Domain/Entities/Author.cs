
namespace Library.Domain.Entities
{
    public class Author : IEntity
    {
        public Author() { }
        public Author(Guid id,string firstName, string surname) 
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
        }
        public Guid Id { get; set; }
        public string FirstName { get;  set; } 
        public string Surname { get;  set; }
        public ICollection<Book>? Books { get; set; }
    }
}
