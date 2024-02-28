using Dapper;
using Npgsql;
using Domain.Models;

namespace Infrastructure.Services;

public class BookService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=LibraryDb;User Id=postgres;Password=2007";


    public List<Book> GetBooks()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Book>("select * from Books").ToList();
    }

    public void AddBook(Book book)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into books (Title,Description,Access) values(@Title,@Description,@Access) ", book);
    }

    public void UpdateBook(Book book)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Books set Title=@Title,Description=@Description,Access=@Access  where Id=@Id ", book);
    }

    public void DeleteBook(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Books where Id=@Id ", new { Id = id });
    }

    public List<Book> SearchBookByTitle(string title)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Book>("select * from Books  where title ilike '%@title%' ", new { Title = title }).ToList();
        return result;
    }

    public List<Book> SearchBookByDescription(string description)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Book>("select * from Books  where Description ilike '%@description%' ", new { Description = description }).ToList();
        return result;
    }

    public void AccessOfBook(Book book)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Books  set Access=@Access  where Id=@Id ", book);
    }

    public List<BookInfo> CountAllBooks()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select Count(*) from Books ").ToList();
    }

}

