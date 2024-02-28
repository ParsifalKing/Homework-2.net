using Dapper;
using Npgsql;
using Domain.Models;

namespace Infrastructure.Services;

public class AuthorService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=LibraryDb;User Id=postgres;Password=2007";


    public List<Author> GetAuthors()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Author>("select * from Authors").ToList();
    }

    public void AddAuthor(Author author)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Authors (FullName,Age) values(@FullName,@Age) ", author);
    }

    public void UpdateAuthor(Author author)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Authors set FullName=@FullName,Age=@Age  where Id=@Id ", author);
    }

    public void DeleteAuthor(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Authors where Id=@Id ", new { Id = id });
    }

    public List<Book> SearchAuthorByFullName(string fullName)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Book>("select * from Authors  where FullName ilike '%@FullName%' ", new { FullName = fullName }).ToList();
        return result;
    }

}
