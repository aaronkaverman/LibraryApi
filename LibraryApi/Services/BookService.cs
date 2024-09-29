using LibraryApi.Models;
using LibraryApi.Repositories.Interface;
using LibraryApi.Services.Interfaces;

namespace LibraryApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<BookService> _logger;
    
    public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }
    
    public IEnumerable<Book> GetBooks()
    {
        return _bookRepository.GetAllBooks();
    }
    
    public Book? GetBook(Guid id)
    {
        try
        {
            return _bookRepository.GetBookById(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, ex.Message);
            throw;
        }
    }

    public Book AddBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);
        
        book.Title = CleanTitle(book.Title);

        if (string.IsNullOrWhiteSpace(book.Title))
        {
            _logger.Log(LogLevel.Error, "Invalid book title");
            throw new InvalidOperationException("Invalid book title");
        }

        if (_bookRepository.GetBookByTitle(book.Title) != null)
        {
            _logger.Log(LogLevel.Error, "Book with this title already exists");
            throw new InvalidOperationException("Book with this title already exists");
        }

        return _bookRepository.CreateBook(book);
    }

    public Book UpdateBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);
        
        book.Title = CleanTitle(book.Title);

        if (string.IsNullOrWhiteSpace(book.Title))
        {
            _logger.Log(LogLevel.Error, "Invalid book title");
            throw new InvalidOperationException("Invalid book title");
        }
        
        var existingBook = _bookRepository.GetBookByTitle(book.Title);
        if (existingBook != null && existingBook.Id != book.Id)
        {
            _logger.Log(LogLevel.Error, "Book with this title already exists");
            throw new InvalidOperationException("Book with this title already exists");
        }

        if (_bookRepository.GetBookById(book.Id) == null)
            throw new KeyNotFoundException("Book not found.");

        return _bookRepository.UpdateBook(book);
    }

    public void DeleteBook(Book book)
    {
        try
        {
            _bookRepository.DeleteBook(book);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, ex.Message);
            throw;
        }
    }

    private static string CleanTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return string.Empty;

        title = title.Trim();

        var words = title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        var camelCasedWords = words
            .Select(word => char.ToUpper(word[0]) + word[1..].ToLower());

        var cleanedTitle = string.Join(" ", camelCasedWords);

        return cleanedTitle;
    }
}