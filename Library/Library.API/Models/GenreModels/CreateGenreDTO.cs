using AutoMapper;
using Library.Application.Commands.GenreCommands.CreateCommand;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Domain.Entities;

namespace Library.API.Models.GenreModels
{
    public class CreateGenreDTO 
    {
  
        public string Name { get; set; }

    }
}
