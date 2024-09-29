using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.Requests;

public class BookRequest
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    public DateTime? PublishedDate { get; set; }
    public Genre? Genre { get; set; }
}