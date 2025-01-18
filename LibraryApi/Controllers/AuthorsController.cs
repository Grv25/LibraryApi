using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        public ILibraryRepository Books { get; set; }

        public AuthorsController(ILibraryRepository books)
        {
            Books = books;
        }
        
        [HttpGet]
        public IEnumerable<BookAuthor> GetAllAuthors()
        {
            return Books.GetAllAuthors();
        }
    }
}
