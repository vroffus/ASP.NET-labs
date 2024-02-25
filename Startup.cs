using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/Library", async context =>
            {
                await context.Response.WriteAsync("Welcome to the Library!");
            });

            endpoints.MapGet("/Library/Books", async context =>
            {
                var books = await ReadBooksFromFile();
                await context.Response.WriteAsync("Books in the Library:\n" + string.Join("\n", books));
            });

            endpoints.MapGet("/Library/Profile/{id?}", async context =>
            {
                var id = context.Request.RouteValues["id"] as string;
                if (string.IsNullOrEmpty(id))
                {
                    await context.Response.WriteAsync("Information about the current user's profile.");
                }
                else
                {
                    var users = await ReadUsersFromFile();
                    var user = FindUserById(users, id);
                    if (user != null)
                    {
                        await context.Response.WriteAsync($"User Information:\nId: {user.Id}\nName: {user.Name}\nAge: {user.Age}\nAddress: {user.Address}\nEmail: {user.Email}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("User not found.");
                    }
                }
            });
        });
    }

    private async Task<List<string>> ReadBooksFromFile()
    {
        var filePath = "books.json"; 
        if (File.Exists(filePath))
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var books = await JsonSerializer.DeserializeAsync<List<Book>>(fileStream, options);
                if (books != null)
                {
                    var bookInfo = new List<string>();
                    foreach (var book in books)
                    {
                        bookInfo.Add($"{book.Title} by ({book.Author}) ({book.Year})");
                    }
                    return bookInfo;
                }
            }
        }
        return new List<string>();
    }

    private async Task<List<User>> ReadUsersFromFile()
    {
        var filePath = "users.json"; 
        if (File.Exists(filePath))
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var users = await JsonSerializer.DeserializeAsync<List<User>>(fileStream, options);
                return users;
            }
        }
        return new List<User>();
    }

    private User FindUserById(List<User> users, string id)
    {
        if (int.TryParse(id, out int userId))
        {
            return users.FirstOrDefault(u => u.Id == userId);
        }
        return null;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}

