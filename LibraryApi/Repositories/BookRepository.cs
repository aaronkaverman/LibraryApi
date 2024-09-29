using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Repositories.Interface;

namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public Book? GetBookById(Guid id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book? GetBookByTitle(string title)
    {
        return _context.Books.FirstOrDefault(b => b.Title == title);
    }

    public Book CreateBook(Book book)
    {
        var createdBook = _context.Books.Add(book);
        _context.SaveChanges();
        return createdBook.Entity;
    }

    public Book UpdateBook(Book book)
    {
        var updatedBook = _context.Books.Update(book);
        _context.SaveChanges();
        return updatedBook.Entity;
    }

    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}