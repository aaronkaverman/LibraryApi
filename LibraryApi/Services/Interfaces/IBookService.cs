using LibraryApi.Models;

namespace LibraryApi.Services.Interfaces;

public interface IBookService
{
    IEnumerable<Book> GetBooks();
    Book? GetBook(Guid id);
    Book AddBook(Book book);
    Book UpdateBook(Book book);
    void DeleteBook(Book book);
}