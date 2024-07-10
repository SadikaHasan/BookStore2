using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Request;
using BookStore.Models.Responses;
using BookStore.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost("GetBooksByAuthor")]
        public async Task<IActionResult>
            GetBooksByAuthor(GetBooksByAuthorRequest? request)
        {
            if (request == null) return BadRequest();

            var result =
                await _libraryService.GetBooksByAuthor(request);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("TestEndpoint")]
        public string GetTestEndpoint(
            [FromBody] TestRequest request)
        {
            return "Test OK";
        }

    }
}
