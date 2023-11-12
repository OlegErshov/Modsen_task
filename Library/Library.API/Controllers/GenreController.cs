using AutoMapper;
using Library.API.Models.BookModels;
using Library.API.Models.GenreModels;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.DeleteCommand;
using Library.Application.Commands.GenreCommands.CreateCommand;
using Library.Application.Commands.GenreCommands.DeleteCommand;
using Library.Application.Commands.GenreCommands.UpdateCommand;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Application.Queries.GenreQueries.GetGenresListQuerie;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseController
    {
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<ActionResult<GenresListReply>> GetList()
        {
            var querie = new GetGenresListQuerie();

            var vw = await Mediator.Send(querie);
            return vw is not null ? Ok(vw) : NotFound();
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get(Guid id)
        {
            var querie = new GetGenreByIdQuerie
            {
                Id = id
            };

            var vw = await Mediator.Send(querie);
            return vw is not null ? Ok(vw) : NotFound();
        }

        // POST api/<GenreController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGenreDTO createGenreDTO)
        {
            var command = _mapper.Map<CreateGenreCommand>(createGenreDTO);

            var genreId = await Mediator.Send(command);
            return Ok(genreId);
        }

        // PUT api/<GenreController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGenreDTO newGenre)
        {
            var command = new UpdateGenreCommand
            {
                Id=id,
                Name = newGenre.Name
            };

            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteGenreCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
