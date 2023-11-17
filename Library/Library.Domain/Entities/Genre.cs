
namespace Library.Domain.Entities
{
    public class Genre : IEntity
    {
        public Genre() { }
        public Genre(Guid id, string name) {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
