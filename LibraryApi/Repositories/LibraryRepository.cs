using LibraryApi.Models;
using System.Collections.Concurrent;

namespace LibraryApi.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private static ConcurrentDictionary<string, Book> _books =
              new ConcurrentDictionary<string, Book>();

        private static ConcurrentDictionary<string, BookAuthor> _authors =
              new ConcurrentDictionary<string, BookAuthor>();

        public LibraryRepository()
        {

        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values;
        }

        public void Add(Book book)
        {
            book.Id = Guid.NewGuid().ToString();

            var existingAuthor = _authors.Values.FirstOrDefault(a => a.FullName == book.Author.FullName);
            if (existingAuthor != null)
            {
                book.Author = existingAuthor;
            }
            else
            {
                book.Author.Id = Guid.NewGuid().ToString();
                _authors[book.Author.Id] = book.Author;
            }

            _books[book.Id] = book;
        }

        public Book Find(string key)
        {
            Book book;
            _books.TryGetValue(key, out book);
            return book;
        }

        public Book Remove(string key)
        {
            Book book;
            _books.TryRemove(key, out book);
            return book;
        }

        public void Update(Book book)
        {
            _books[book.Id] = book;
        }

        public IEnumerable<BookAuthor> GetAllAuthors()
        {
            return _authors.Values;
        }
    }
}
