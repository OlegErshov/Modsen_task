using AutoMapper;
using Library.API.Models.AuthorModels;
using Library.API.Models.BookModels;
using Library.Application.Commands.AuthorCommands.CreateCommand;
using Library.Application.Commands.BookCommands.CreateCommand;
using Library.Application.Commands.BookCommands.DeleteCommand;
using Library.Application.Commands.BookCommands.UpdateCommand;
using Library.Application.Queries.BookQueries.GetBookQueries;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByIdQuerie;
using Library.Application.Queries.BookQueries.GetBookQueries.GetByISBNQuerie;
using Library.Application.Queries.BookQueries.GetBooksListQueries;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [Authorize]
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
            var command = _mapper.Map<CreateBookCommand>(createBookDTO);

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
                Id = id,
                Title = updateBookDTO.Title,
                Description = updateBookDTO.Description,
                ISBN = updateBookDTO.ISBN,
                RecieveDate = updateBookDTO.RecieveDate,
                ReturnDate = updateBookDTO.ReturnDate,
                AuthorReply = updateBookDTO.AuthorReply,
                GenreReply = updateBookDTO.GenreReply
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
