using LibraryApi.Models;
using LibraryApi.Models.Requests;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all books available in the library.
    /// </summary>
    /// <returns>
    /// A list of all books in the system.
    /// </returns>
    /// <response code="200">A list of books was returned successfully.</response>
    /// <response code="204">No books were found in the library.</response>
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(bookService.GetBooks());
    }

    /// <summary>
    /// Retrieves the details of a specific book by its unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <returns>
    /// A specific book's details if found; otherwise, a 404 Not Found response.
    /// </returns>
    /// <response code="200">The book was found and returned successfully.</response>
    /// <response code="404">The book with the specified ID was not found.</response>
    [HttpGet("{id:guid}")]
    public ActionResult<Book> GetBook(Guid id)
    {
        var book = bookService.GetBook(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    /// <summary>
    /// Creates a new book in the system
    /// </summary>
    /// <param name="request">The object containing the book details.</param>
    /// <returns>
    /// A status code indicating the result of the update operation.
    /// </returns>
    /// <response code="200">The book was successfully created.</response>
    /// <response code="400">Bad request, the provided data is invalid.</response>
    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] BookRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var book = new Book()
        {
            Title = request.Title,
            Author = request.Author,
            PublishedDate = request.PublishedDate ?? DateTime.Now,
            Genre = request.Genre ?? Genre.Unknown,
        };

        try
        {
            book = bookService.AddBook(book);
            return Ok(book);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Updates an existing book in the system.
    /// </summary>
    /// <param name="id">The unique ID of the book to update.</param>
    /// <param name="request">The object containing the book details.</param>
    /// <returns>
    /// A status code indicating the result of the update operation.
    /// </returns>
    /// <response code="200">The book was successfully updated.</response>
    /// <response code="404">Not found, the book with the specified ID does not exist.</response>
    /// <response code="400">Bad request, the provided data is invalid.</response>
    [HttpPut("{id:guid}")]
    public ActionResult UpdateBook(Guid id, [FromBody] BookRequest request)
    {
        var book = bookService.GetBook(id);
        if (book == null)
        {
            return NotFound();
        }

        book.Title = request.Title;
        book.Author = request.Author;

        if (request.PublishedDate != null) book.PublishedDate = request.PublishedDate.Value;

        if (request.Genre != null)
        {
            if (Enum.IsDefined(typeof(Genre), request.Genre))
            {
                book.Genre = request.Genre.Value;
            }
            else
            {
                return BadRequest("Invalid genre specified.");
            }
        }

        try
        {
            return Ok(bookService.UpdateBook(book));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    /// <summary>
    /// Deletes a book from the system.
    /// </summary>
    /// <param name="id">The unique ID of the book to delete.</param>
    /// <returns>
    /// A status code indicating the result of the delete operation.
    /// </returns>
    /// <response code="200">The book was successfully deleted.</response>
    /// <response code="404">Not found, the book with the specified ID does not exist.</response>
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteBook(Guid id)
    {
        var book = bookService.GetBook(id);
        if (book == null)
        {
            return NotFound();
        }

        try
        {
            bookService.DeleteBook(book);
            return Ok("Book deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}