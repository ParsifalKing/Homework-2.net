using Dapper;
using Npgsql;
using Domain.Models;

namespace Infrastructure.Services;

public class BookCategory_Service
{

    private string _connectionString = "Server=localhost;Port=5432;Database=LibraryDb;User Id=postgres;Password=2007";


    public List<BookInfo> GetBooks_Category()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access,c.CategoryName from Books_Categories as bc join Books as b on b.Id = bc.BookId join Categories as c on c.Id = bc.CategoryId order by b.Title,b.Description  ").ToList();
    }

    public void AddBook_Category(BookInfo bookInfo)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Books_Categories (BookId,CategoryId) values(@BookId,@CategoryId) ", bookInfo);
    }

    public void UpdateBook_Category(BookInfo bookInfo)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Books_Categories set BookId=@BookId,CategoryId=@CategoryId  where Id=@Id ", bookInfo);
    }

    // we count all categories of books
    public List<BookInfo> CountAllCategory_Books()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access,Count(BookId) from Books_Categories as bc join Books as b on b.Id = bc.BookId join Categories as c on c.Id = bc.CategoryId group by b.Title,b.Description,b.Access order by b.Title,b.Description,b.Access ").ToList();
    }
    // we count all categories of one book
    public List<BookInfo> CountCategory_Books(int bookId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select b.Title,b.Description,b.Access,Count(BookId) from Books_Categories as bc join Books as b on b.Id = bc.BookId join Categories as c on c.Id = bc.CategoryId where bc.BookId=@Id group by b.Title,b.Description,b.Access order by b.Title,b.Description,b.Access ", new { Id = bookId }).ToList();
    }


    // we count all books of categories
    public List<BookInfo> CountAllBook_Categories()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select c.CategoryName,Count(CategoryId) from Books_Categories as bc join Books as b on b.Id = bc.BookId join Categories as c on c.Id = bc.CategoryId group by c.CategoryName ").ToList();
    }


    // we count all books of one category
    public List<BookInfo> CountBook_Categories(int categoryId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<BookInfo>("select c.CategoryName,Count(CategoryId) from Books_Categories as bc join Books as b on b.Id = bc.BookId join Categories as c on c.Id = bc.CategoryId where bc.CategoryId=@Id group by c.CategoryName  ", new { Id = categoryId }).ToList();
    }
}
