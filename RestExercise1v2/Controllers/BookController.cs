using Microsoft.AspNetCore.Mvc;
using ObligatoriskOpgave2023;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercise1v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BooksRepository MyRepository = new BooksRepository();

        public BookController(BooksRepository booksRepository)
        {
            MyRepository = booksRepository; 
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return MyRepository.Get();
        }

        // GET api/<BookController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Book book = MyRepository.GetBookById(id);
            if (book == null) return NotFound("No Such Book, Id: " + id);
            return Ok(book);
            //return MyRepository.GetBookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return MyRepository.Add(value);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody] Book value)
        {
            return MyRepository.Update(id, value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            return MyRepository.Remove(id);
        }
    }
}
