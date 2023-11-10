using Library.Application.Queries.BookQueries.GetBooksListQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetGenresListQuerie
{
    public class GenresListReply
    {
        public List<GenresListDTO> Genres { get; set; }
    }
}
