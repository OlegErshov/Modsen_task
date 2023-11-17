using Library.Application.Commands.BookCommands.Models;


namespace Library.Application.Queries.BookQueries.GetBooksListQueries
{
    public class BooksListDTO 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }
    }
}
