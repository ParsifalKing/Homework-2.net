using Domain.Models;
using Npgsql;
using Dapper;

namespace Infrastructure.Services;

public class CustomerService
{

    private string _connectionString = "Server=localhost;Port=5432;Database=ShopDb;User Id=postgres;Password=2007";


    public List<Customer> GetCustomers()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Customer>("select * from Customers").ToList();
    }

    public void AddCustomer(Customer customer)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Customers (FullName,Age,Email,CountryId) values(@FullName,@Age,@Email,@CountryId) ", customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Customers set FullName=@FullName,Age=@Age,Email=@Email,CountryId=@CountryId  where Id=@Id ", customer);
    }

    public void DeleteCustomer(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Customers where Id=@Id ", new { Id = id });
    }

    public List<Customer> GetAllCustomersByAge(int age)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<Customer>("select * from Customers  where Age = @Age ", new { Age = age }).ToList();
        return result;
    }

    public Customer GetCustomerByEmail(string email)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.QuerySingle<Customer>("select * from Customers  where Email = @Email ", new { Email = email });
        return result;
    }

    public int CountAllCustomers()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        int count = Convert.ToInt32(connection.QueryFirstOrDefault<int>("select Count(*) from Customers "));
        return count;
    }

}
