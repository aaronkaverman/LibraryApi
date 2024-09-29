using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .Property(b => b.Genre)
            .HasConversion<string>();

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = Guid.Parse("E1452783-17F5-432E-823B-D963B3C02264"),
                Title = "Treasure Island",
                Author = "Robert Louis Stevenson",
                Genre = Genre.Adventure,
                PublishedDate = new DateTime(1883, 11, 14)
            },
            new Book
            {
                Id = Guid.Parse("7B41E4C2-6351-43E9-B734-B5A7418C96A0"),
                Title = "Jurassic Park",
                Author = "Michael Crichton",
                Genre = Genre.Adventure,
                PublishedDate = new DateTime(1990, 11, 20)
            },
            new Book
            {
                Id = Guid.Parse("69BADAA9-BDBC-4269-A3B4-C0F145EC4704"),
                Title = "The Very Hungry Caterpillar",
                Author = "Eric Carle",
                Genre = Genre.Children,
                PublishedDate = new DateTime(1969, 6, 3)
            },
            new Book
            {
                Id = Guid.Parse("C4B38AC8-4923-4C8C-BF1B-C4F44D70FEE8"),
                Title = "Murder on the Orient Express",
                Author = "Agatha Christie",
                Genre = Genre.Mystery,
                PublishedDate = new DateTime(1934, 1, 1)
            },
            new Book
            {
                Id = Guid.Parse("BFD63F97-B915-4EDC-9A9F-90C13EA24E42"),
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genre = Genre.Romance,
                PublishedDate = new DateTime(1813, 1, 28)
            },
            new Book
            {
                Id = Guid.Parse("CFD122FD-4DDA-41C5-99E1-42DA33699843"),
                Title = "It Ends with Us",
                Author = "Colleen Hoover",
                Genre = Genre.Romance,
                PublishedDate = new DateTime(2016, 8, 2)
            },
            new Book
            {
                Id = Guid.Parse("A361CC74-8494-49B8-B716-176FB343C743"),
                Title = "The Hitchhiker's Guide to the Galaxy",
                Author = "Douglas Adams",
                Genre = Genre.ScienceFiction,
                PublishedDate = new DateTime(1987, 10, 12)
            },
            new Book
            {
                Id = Guid.Parse("2A4F5BD6-B5EB-42E2-8237-BCEA33725094"),
                Title = "1984",
                Author = "George Orwell",
                Genre = Genre.ScienceFiction,
                PublishedDate = new DateTime(1949, 6, 8)
            },
            new Book
            {
                Id = Guid.Parse("23F07067-55D0-4A8A-BF75-A0A71CD2DCC9"),
                Title = "Dracula",
                Author = "Bram Stoker",
                Genre = Genre.Horror,
                PublishedDate = new DateTime(1897, 5, 26)
            },
            new Book
            {
                Id = Guid.Parse("FC2E239A-5FE0-44A8-9345-CC9EC80EB923"),
                Title = "The Shining",
                Author = "Stephen King",
                Genre = Genre.Horror,
                PublishedDate = new DateTime(1977, 1, 28)
            },
            new Book
            {
                Id = Guid.Parse("1C5A81A8-D678-4414-9FE8-C6EB601AD682"),
                Title = "It",
                Author = "Stephen King",
                Genre = Genre.Horror,
                PublishedDate = new DateTime(1985, 9, 15)
            }
        );
    }
}