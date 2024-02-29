using Domain.Models;
using Dapper;
using Npgsql;
namespace Infrastructure.Services;

public class CountryService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=ShopDb;User Id=postgres;Password=2007";


    public List<Country> GetCountryies()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<Country>("select * from Countries").ToList();
    }

    public void AddCountry(Country country)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("insert into Countryies (Name) values(@Name) ", country);
    }

    public void UpdateCountry(Country country)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Countryies set Name=@Name  where Id=@Id ", country);
    }

    public void DeleteCountry(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Countries where Id=@Id ", new { Id = id });
    }

    public Country SearchCountryById(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.QuerySingleOrDefault<Country>("select * from Countries  where Id = @Id ", new { Id = id });
        return result;
    }

    public Country SearchCountryByName(string name)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.QueryFirstOrDefault<Country>("select * from Countries  where Name = @Name ", new { Name = name });
        return result;
    }

    public int CountAllCountries()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        int count = Convert.ToInt32(connection.ExecuteScalar<int>("select Count(*) from Countries "));
        return count;
    }
}
