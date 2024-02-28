using Dapper;
using Npgsql;
using Domain.Models;

namespace Infrastructure.Services;

public class BookAuthor_Service
{

    private string _connectionString = "Server=localhost;Port=5432;Database=LibraryDb;User Id=postgres;Password=2007";


    public List<BookInfo> GetBooks_Author()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access,a.FullName,a.Age from Books_Author as ba join Books as b on b.Id = ba.BookId join Authors as a on a.Id = ba.AuthorId ").ToList();
    }

    public void AddBook_Author(BookInfo bookInfo)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Books_Author (BookId,AuthorId) values(@BookId,@AuthorId) ", bookInfo);
    }

    public void UpdateBook_Author(BookInfo bookInfo)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Books_Author set BookId=@BookId,AuthorId=@AuthorId  where Id=@Id ", bookInfo);
    }


    public List<BookInfo> CountAllAuthors_Books()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select a.FullName,a.Age,Count(BookId) from Books_Author as ba join Authors as a on a.Id = ba.AuthorId join Books as b on b.Id = ba.BookId group by a.FullName, a.Age ").ToList();
    }

    public List<BookInfo> CountAuthor_Books(int authorId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select a.FullName,a.Age,Count(BookId) from Books_Author as ba join Authors as a on a.Id = ba.AuthorId join Books as b on b.Id = ba.BookId where ba.AuthorId=@Id group by a.FullName, a.Age ", new { Id = authorId }).ToList();
    }

    public List<BookInfo> CountBook_Author(int bookId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access, Count(AuthorId) from Books_Author as ba join Authors as a on a.Id = ba.AuthorId join Books as b on b.Id = ba.BookId where ba.BookId=@Id group by b.Title,b.Description,b.Access ", new { Id = bookId }).ToList();
    }

    public List<BookInfo> CountAllBook_Author()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access, Count(AuthorId) from Books_Author as ba join Authors as a on a.Id = ba.AuthorId join Books as b on b.Id = ba.BookId group by b.Title,b.Description,b.Access ").ToList();
    }



}
