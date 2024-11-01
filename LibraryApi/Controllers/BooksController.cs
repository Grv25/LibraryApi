using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public ILibraryRepository Books { get; set; }

        public BooksController(ILibraryRepository books)
        {
            Books = books;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return Books.GetAll();
        }

        [HttpGet("{id}", Name = "GetBooks")]
        public IActionResult GetById(string id)
        {
            var book = Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return new ObjectResult(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            Books.Add(book);
            return CreatedAtRoute("GetBooks", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var findedBook = Books.Find(id);
            if (findedBook == null)
            {
                return NotFound();
            }

            book.Id = findedBook.Id;

            Books.Update(book);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var findedBook = Books.Find(id);
            if (findedBook == null)
            {
                return NotFound();
            }

            Books.Remove(id);
            return new NoContentResult();
        }
    }
}
