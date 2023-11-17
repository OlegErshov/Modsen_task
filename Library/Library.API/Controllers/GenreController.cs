using AutoMapper;
using Library.Application.Commands.GenreCommands.CreateCommand;
using Library.Application.Commands.GenreCommands.DeleteCommand;
using Library.Application.Commands.GenreCommands.UpdateCommand;
using Library.Application.Queries.GenreQueries.GetByIdQuerie;
using Library.Application.Queries.GenreQueries.GetGenresListQuerie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
            var command = new CreateGenreCommand
            {
                createGenreDTO = createGenreDTO
            };
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
                updateGenreDTO = newGenre
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
