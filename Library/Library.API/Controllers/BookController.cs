using AutoMapper;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.DeleteCommand;
using Library.Application.Commands.BookCommands.Models;
using Library.Application.Commands.BookCommands.UpdateCommand;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByISBNQuerie;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<BooksListReply>> GetList()
        {
            var querie = new GetBooksListQuerie();

            var vw = await Mediator.Send(querie);
            return Ok(vw);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> Get(Guid id)
        {
            var querie = new GetBookByIdQuerie
            {
                Id = id
            };

            var vw = await Mediator.Send(querie);
            return Ok(vw);
        }

        
        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<BookDTO>> GetByISBN(string isbn)
        {
            var querie = new GetBookByISBNQuerie
            {
                ISBN = isbn
            };

            var vw = await Mediator.Send(querie);
            return Ok(vw);
        }


        // POST api/<BookController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDTO createBookDTO)
        {
            var command = new CreateBookCommand
            {
                createBookDTO = createBookDTO
            };

            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        // PUT api/<BookController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDTO updateBookDTO)
        {
            var command = new UpdateBookCommand
            {
                updateBookDTO = updateBookDTO
            };
            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            { 
                Id = id 
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
