using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1c5a81a8-d678-4414-9fe8-c6eb601ad682"), "Stephen King", "Horror", new DateTime(1985, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "It" },
                    { new Guid("23f07067-55d0-4a8a-bf75-a0a71cd2dcc9"), "Bram Stoker", "Horror", new DateTime(1897, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dracula" },
                    { new Guid("2a4f5bd6-b5eb-42e2-8237-bcea33725094"), "George Orwell", "ScienceFiction", new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { new Guid("69badaa9-bdbc-4269-a3b4-c0f145ec4704"), "Eric Carle", "Children", new DateTime(1969, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Very Hungry Caterpillar" },
                    { new Guid("7b41e4c2-6351-43e9-b734-b5a7418c96a0"), "Michael Crichton", "Adventure", new DateTime(1990, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { new Guid("a361cc74-8494-49b8-b716-176fb343c743"), "Douglas Adams", "ScienceFiction", new DateTime(1987, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("bfd63f97-b915-4edc-9a9f-90c13ea24e42"), "Jane Austen", "Romance", new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { new Guid("c4b38ac8-4923-4c8c-bf1b-c4f44d70fee8"), "Agatha Christie", "Mystery", new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murder on the Orient Express" },
                    { new Guid("cfd122fd-4dda-41c5-99e1-42da33699843"), "Colleen Hoover", "Romance", new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "It Ends with Us" },
                    { new Guid("e1452783-17f5-432e-823b-d963b3c02264"), "Robert Louis Stevenson", "Adventure", new DateTime(1883, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treasure Island" },
                    { new Guid("fc2e239a-5fe0-44a8-9345-cc9ec80eb923"), "Stephen King", "Horror", new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shining" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
