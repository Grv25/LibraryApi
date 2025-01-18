using LibraryApi.Models;

namespace LibraryApi.Repositories
{
    public interface ILibraryRepository
    {
        void Add(Book book);  // POST /api/books - Создать новую книгу.
        IEnumerable<Book> GetAll();  // GET /api/books - Получить список всех книг.
        Book Find(string key);  // GET /api/books/{id} - Получить книгу по идентификатору.
        Book Remove(string key);  // DELETE /api/books/{id} - Удалить книгу.
        void Update(Book item);  // PUT /api/books/{id} - Обновить информацию о книге.
        IEnumerable<BookAuthor> GetAllAuthors();  // GET /api/authors/ - Получить список всех авторов.
    }
}
