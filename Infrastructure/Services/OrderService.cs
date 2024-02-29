using Domain.Models;
using Npgsql;
using Dapper;

namespace Infrastructure.Services;

public class OrderService
{
    private string _connectionString = "Server=localhost;Port=5432;Database=ShopDb;User Id=postgres;Password=2007";

    // public List<OrderType> GetOrders()
    // {
    //     using var connection = new NpgsqlConnection(_connectionString);
    //     var query = connection.QueryMultiple(@"select * from Orders; 
    //     select * from Products;
    //     select * from Customers;
    //     select * from Countries; ");
    //     var item = query.Read<OrderType>().ToList();
    //     return item;
    // }

    public List<OrderType> GetOrders()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select c.FullName,c.Age,c.Email,o.Description,o.OrderTime,ct.Name as CountryName,p.Name as ProductName,p.Price,p.DateOfCreation
        from Orders as o
        join Customers as c on o.CustomerId = c.Id
        join Products as p on o.ProductId = p.Id
        join Countries as ct on o.CountryId = ct.Id
        ").ToList();
        return query;
    }

    public void AddOrder(Order order)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute(@"insert into Orders (Description,OrderTime,ProductId,CustomerId,CountryId)
         values(@Description,@OrderTime,@ProductId,@CustomerId,@CountryId) ", order);
    }

    public void UpdateOrder(Order order)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("update Orders set Description=@Description,OrderTime=@OrderTime,ProductId=@ProductId,CustomerId=@CustomerId,CountryId=@CountryId  where Id=@Id ", order);
    }

    public void DeleteOrder(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute("delete from Orders where Id=@Id ", new { Id = id });
    }

    public List<OrderType> SearchOrdersByDateTime(DateTime orderTime)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var result = connection.Query<OrderType>(@"select c.FullName,c.Age,c.Email,o.Description,o.OrderTime,ct.Name as CountryName,p.Name as ProductName,p.Price,p.DateOfCreation
        from Orders as o
        join Customers as c on o.CustomerId = c.Id
        join Products as p on o.ProductId = p.Id
        join Countries as ct on o.CountryId = ct.Id
        where OrderTime > @OrderTime ", new { OrderTime = orderTime }).ToList();
        return result;
    }

    public int CountAllOrders()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        int count = Convert.ToInt32(connection.ExecuteScalar<int>("select Count(*) from Orders "));
        return count;
    }
    // first - 1
    public List<OrderType> TenPopularOrders()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select  Count(o.ProductId), p.Name as ProductName,p.Price,p.DateOfCreation 
        from Orders as o
        right join Products as p on o.ProductId = p.Id
        where o.OrderTime > '2024-01-23'
        group by o.ProductId,p.Name,p.Price,p.DateOfCreation
        order by Count desc limit 10
        ").ToList();
        return query;
    }
    // second - 2
    public List<OrderType> CountOfCustomersOrders()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select Count(o.CustomerId),cus.FullName,cus.Age,cus.Email
        from Orders as o 
        right join Products as p on o.ProductId = p.Id
        right join Customers as cus on o.CustomerId = cus.Id
        group by cus.FullName,cus.Age,cus.Email 
        order by Count desc
        ").ToList();
        return query;
    }
    // third - 3
    public List<OrderType> CountMonthOrdersOfCountry()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select Count(*), c.Name as CountryName
        from Orders as o
        full outer join Countries as c on c.Id = o.CountryId
        where o.OrderTime > '2024-01-29'
        group by CountryName 
        order by Count desc
        ").ToList();
        return query;
    }
    public List<OrderType> CountYearOrdersOfCountry()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select Count(*), c.Name as CountryName
        from Orders as o
        full outer join Countries as c on c.Id = o.CountryId
        where o.OrderTime > '2023-02-28'
        group by CountryName 
        order by Count desc
        ").ToList();
        return query;
    }

    // forth - 4
    public List<OrderType> BestCustomerOfMonth()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select Count(o.ProductId),cus.FullName,cus.Age,cus.Email
        from Orders as o
        left join Customers as cus on o.CustomerId = cus.Id
        where o.OrderTime > '2024-01-29'
        group by cus.FullName,cus.Age,cus.Email
        order by Count desc limit 1
        ").ToList();
        return query;
    }

    public List<OrderType> BestCustomerOfYear()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = connection.Query<OrderType>(@"select Count(o.ProductId),cus.FullName,cus.Age,cus.Email
        from Orders as o
        left join Customers as cus on o.CustomerId = cus.Id
        where o.OrderTime > '2023-02-28'
        group by cus.FullName,cus.Age,cus.Email
        order by Count desc limit 1
        ").ToList();
        return query;
    }





}
