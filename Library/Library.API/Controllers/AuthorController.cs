using AutoMapper;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Commands.AuthorCommands.DeleteCommand;
using Library.Application.Commands.AuthorCommands.UpdateCommand;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {

        private readonly IMapper _mapper;
        public AuthorController(IMapper mapper) => _mapper = mapper;

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> Get(Guid id)
        {
            var querie = new GetAuthorByIdQuerie
            {
                id = id
            };

            var vm = await Mediator.Send(querie);

            return vm is not null ? Ok(vm) : NotFound();
        }

        // POST api/<AuthorController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDTO сreateAuthorDTO)
        {
            var command = new CreateAuthorCommand
            {
                createAuthorDTO = сreateAuthorDTO
            };
            var authorId = await Mediator.Send(command);
            return Ok(authorId);
        }

        // PUT api/<AuthorController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult>  Update(Guid id, [FromBody] UpdateAuthorDTO updateAuthorDTO)
        {
            var command = new UpdateAuthorCommand
            {
                updateAuthorDTO = updateAuthorDTO
            };
            await Mediator.Send(command);   
            return NoContent();
        }

        // DELETE api/<AuthorController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
