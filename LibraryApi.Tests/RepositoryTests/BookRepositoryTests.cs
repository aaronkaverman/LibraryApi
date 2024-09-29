using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Tests.RepositoryTests;

public class BookRepositoryTests
{
    private readonly BookRepository _bookRepository;

    public BookRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: "TestLibrary")
            .Options;

        var context = new LibraryContext(options);
        _bookRepository = new BookRepository(context);
    }
    
    [Fact]
    public void CreateBook_ShouldAddBookToDatabase()
    {
        var book = new Book
        {
            Id = Guid.NewGuid(), 
            Title = "New Book",
            Author = "New Author",
            PublishedDate = DateTime.Today,
            Genre = Genre.Horror
        };

        _bookRepository.CreateBook(book);
        var result = _bookRepository.GetBookById(book.Id);

        Assert.NotNull(result);
        Assert.Equal("New Book", result.Title);
        Assert.Equal("New Author", result.Author);
        Assert.Equal(DateTime.Today, result.PublishedDate);
        Assert.Equal(Genre.Horror, result.Genre);
    }
}