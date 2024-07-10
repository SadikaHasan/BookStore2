using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Models;
using BookStore.Models.Models.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAll();

            if (result.Count == 0) return NoContent();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(id);
            }

            var response = await _authorService.GetById(id);

            if (response == null)
            {
                return NotFound(id);
            }

            return Ok(response);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            if (author == null) return BadRequest(author);

            await _authorService.Add(author);

            return Ok();
        }
    }
}
