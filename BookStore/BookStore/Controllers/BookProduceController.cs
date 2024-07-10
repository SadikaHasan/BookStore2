using BookStore.BL.Background;
using BookStore.Models.Models;
using BookStore.Models.Request;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookProduceController : ControllerBase
    {
        private readonly IBookProducer _bookProducer;
        
        public BookProduceController(IBookProducer bookProducer)
        {
            _bookProducer = bookProducer;
        }
        [HttpPost("ProduceBook")]
        public async Task<BookProducer>
           ProduceBook(Book book)
        {
            if (book == null) return null;
            await _bookProducer.Produce(book);

            
        }
    }
}
