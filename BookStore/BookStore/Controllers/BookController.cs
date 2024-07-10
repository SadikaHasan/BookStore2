using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id==Guid.Empty) return BadRequest(id);

            var result = 
                await _bookService.GetBookById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            if (book == null) return BadRequest(book);

            await _bookService.AddBook(book);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id==Guid.Empty) return BadRequest(id);

            await _bookService.DeleteBook(id);

            return Ok();
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _bookService.GetAll();

            if (result.Count == 0) 
                return NoContent();

            return Ok(result);
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            if (book == null) return BadRequest(book);

            await _bookService.UpdateBook(book);

            return Ok();
        }
    }
}
