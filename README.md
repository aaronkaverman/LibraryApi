# LibraryApi

LibraryApi is a RESTful web API built using ASP.NET Core that allows users to manage a collection of books. This application demonstrates core development practices and patterns in a .NET environment.

## Features

- **CRUD Operations**: Create, read, update, and delete book records.
- **MVC Architecture**: Separation of concerns with models, views (API endpoints), and controllers.
- **Dependency Injection**: Use of DI to manage service lifetimes and enhance testability.
- **Entity Framework Core**: Utilizes EF Core for database interactions, including migrations and querying.
- **Swagger/OpenAPI**: Integrated Swagger UI for API testing and documentation.
- **SOLID Principles**: Adherence to clean code practices and SOLID design principles.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server or an In-Memory Database (for testing)

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/aaronkaverman/LibraryApi

2. **Navigate to the project directory:**:
   ```bash
   cd LibraryApi
   
3. **Restore the dependencies:**:
   ```bash
   dotnet restore

4. **Set up the database (if using SQL Server):**:
   - update your appsettings.json with your database connection string.
   - Run migrations to create the database:
      ```bash
      dotnet ef database update

5. **Run the project:**:
   ```bash
   dotnet run
   
6. **Access the Swagger UI:**:
    - Navigate to http://localhost:5000/swagger (or the port specified) in your browser to explore and test the API endpoints

## API Endpoints
- Get all books: GET /api/books
- Get a specific book: GET /api/books/{id}
- Create a new book: POST /api/books
- Update an existing book: PUT /api/books/{id}
- Delete a book: DELETE /api/books/{id}

## Usage Example:

    POST /api/books
    {
        "title": "The Three-Body Problem",
        "author": "	Liu Cixin",
        "genre": "ScienceFiction",
        "publishedDate": "2008-01-15"
    }

## Running Test:
- This project includes unit tests for core functionality. To run the tests:
  ```bash
  dotnet test
