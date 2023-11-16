using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands.Models
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public AuthorReply AuthorReply { get; set; }
        public GenreReply GenreReply { get; set; }
    }
}
