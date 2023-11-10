using AutoMapper;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetGenresListQuerie
{
    public class GenresListDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        
    }
}
