using Dapper;
using Npgsql;
using Domain.Models;

namespace Infrastructure.Services;

public class CategoryService
{

    private string _connectionString = "Server=localhost;Port=5432;Database=LibraryDb;User Id=postgres;Password=2007";

    public List<Category> GetCategories()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Category>("select * from Categories").ToList();
    }

    public void AddCategory(Category category)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Categories (CategoryName) values(@CategoryName) ", category);
    }

    public void UpdateCategory(Category category)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Categories set CategoryName=@CategoryName  where Id=@Id ", category);
    }

    public void DeleteCategory(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Categories where Id=@Id ", new { Id = id });
    }

    public List<Book> SearchCategoryByName(string categoryName)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Book>("select * from Categories  where CategoryName ilike '%@CategoryName%' ", new { CategoryName = categoryName }).ToList();
        return result;
    }

}
