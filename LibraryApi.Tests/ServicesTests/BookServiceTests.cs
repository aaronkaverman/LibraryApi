using LibraryApi.Models;
using LibraryApi.Repositories.Interface;
using LibraryApi.Services;
using Moq;

namespace LibraryApi.Tests.ServicesTests;

public class BookServiceTests
{
    private readonly BookService _bookService;
    private readonly Mock<IBookRepository> _bookRepositoryMock;

    public BookServiceTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _bookService = new BookService(_bookRepositoryMock.Object, null);
    }
    
    [Fact]
    public void GetBook_ShouldReturnBook_WhenBookExists()
    {
        var bookId = Guid.NewGuid();
        var book = new Book { Id = bookId, Title = "Test Book" };
        _bookRepositoryMock.Setup(repo => repo.GetBookById(bookId)).Returns(book);
        
        var result = _bookService.GetBook(bookId);
        
        Assert.NotNull(result);
        Assert.Equal(bookId, result.Id);
    }
    
    [Fact]
    public void GetBook_ShouldReturnNull_WhenBookDoesNotExist()
    {
        var bookId = Guid.NewGuid();
        _bookRepositoryMock.Setup(repo => repo.GetBookById(bookId)).Returns((Book)null!);

        var result = _bookService.GetBook(bookId);

        Assert.Null(result);
    }
    
    [Fact]
    public void AddBook_ShouldCallCreateBook()
    {
        var book = new Book { Id = Guid.NewGuid(), Title = "New Book" };

        _bookService.AddBook(book);

        _bookRepositoryMock.Verify(repo => repo.CreateBook(book), Times.Once);
    }
}