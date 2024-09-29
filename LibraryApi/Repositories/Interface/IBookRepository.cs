using LibraryApi.Models;

namespace LibraryApi.Repositories.Interface;

public interface IBookRepository
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(Guid id);
    Book? GetBookByTitle(string title);
    Book CreateBook(Book book);
    Book UpdateBook(Book book);
    void DeleteBook(Book book);
}