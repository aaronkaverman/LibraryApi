using LibraryApi.Repositories;
using LibraryApi.Repositories.Interface;
using LibraryApi.Services;
using LibraryApi.Services.Interfaces;

namespace LibraryApi.Configuration;

public static class ServiceRegister
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddTransient<IBookService, BookService>();
    }
}