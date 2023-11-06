using AutoMapper;
using Library.API.Models.AuthorModels;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Commands.AuthorCommands.DeleteCommand;
using Library.Application.Commands.AuthorCommands.UpdateCommand;
using Library.Application.Queries.AuthorQueries.GetByIdQuerie;
using Library.Domain.Entities;
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
            return Ok(vm);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] СreateAuthorDTO сreateAuthorDTO)
        {
            var command = _mapper.Map<CreateAuthorCommand>(сreateAuthorDTO);

            var authorId = await Mediator.Send(command);
            return Ok(authorId);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>  Update(Guid id, [FromBody] Author author)
        {
            var command = new UpdateAuthorCommand
            {
                Id = id,
                FirstName = author.FirstName,
                Surname = author.Surname
            };

            await Mediator.Send(command);   
            return NoContent();
        }

        // DELETE api/<AuthorController>/5
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
