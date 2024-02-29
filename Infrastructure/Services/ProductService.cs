using Domain.Models;
using Npgsql;
using Dapper;

namespace Infrastructure.Services;

public class ProductService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=ShopDb;User Id=postgres;Password=2007";


    public List<Product> GetProducts()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Product>("select * from Products").ToList();
    }

    public void AddProduct(Product product)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Products (Name,Price,DateOfCreation) values(@Name,@Price,@DateOfCreation) ", product);
    }

    public void UpdateProduct(Product product)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Products set Name=@Name,Price=@Price,DateOfCreation=@DateOfCreation  where Id=@Id ", product);
    }

    public void DeleteProduct(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Products where Id=@Id ", new { Id = id });
    }

    public Product SearchProductByName(string name)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.QueryFirstOrDefault<Product>("select * from Products  where Name ilike '%@Name%' ", new { Name = name });
        return result;
    }

    public List<Product> SearchProductsByDateOfCreation(DateTime dateOfCreation)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Product>("select * from Products  where DateOfCreation > @DateOfCreation ", new { DateOfCreation = dateOfCreation }).ToList();
        return result;
    }

    public int CountAllProducts()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        int count = Convert.ToInt32(connection.ExecuteScalar<int>("select Count(*) from Products "));
        return count;
    }

}
