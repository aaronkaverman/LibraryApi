using LibraryApi.Controllers;
using LibraryApi.Models;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryApi.Tests.ControllerTests;

public class BookControllerTests
{
    private readonly BooksController _controller;
    private readonly Mock<IBookService> _bookServiceMock;

    public BookControllerTests()
    {
        _bookServiceMock = new Mock<IBookService>();
        _controller = new BooksController(_bookServiceMock.Object);
    }
    
    [Fact]
    public void GetBook_ShouldReturnNotFound_WhenBookDoesNotExist()
    {
        var bookId = Guid.NewGuid();
        _bookServiceMock.Setup(service => service.GetBook(bookId)).Returns((Book)null!);

        var result = _controller.GetBook(bookId);

        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public void GetBook_ShouldReturnOk_WhenBookExists()
    {
        var bookId = Guid.NewGuid();
        var book = new Book { Id = bookId, Title = "Existing Book" };
        _bookServiceMock.Setup(service => service.GetBook(bookId)).Returns(book);

        var result = _controller.GetBook(bookId);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedBook = Assert.IsType<Book>(okResult.Value);
        Assert.Equal(bookId, returnedBook.Id);
    }
    
    [Fact]
    public void DeleteBook_ShouldReturnNotFound_WhenBookDoesNotExist()
    {
        var bookId = Guid.NewGuid();
        _bookServiceMock.Setup(service => service.GetBook(bookId)).Returns((Book)null!);

        var result = _controller.DeleteBook(bookId);

        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public void DeleteBook_ShouldReturnOk_WhenBookIsDeleted()
    {
        var bookId = Guid.NewGuid();
        var book = new Book { Id = bookId, Title = "Book to Delete" };
        _bookServiceMock.Setup(service => service.GetBook(bookId)).Returns(book);
        _bookServiceMock.Setup(service => service.DeleteBook(book));

        var result = _controller.DeleteBook(bookId);

        Assert.IsType<OkObjectResult>(result);
    }
}