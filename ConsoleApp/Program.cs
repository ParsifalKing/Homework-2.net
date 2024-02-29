using Domain.Models;
using Infrastructure.Services;


var productServ = new ProductService();
foreach (var item in productServ.GetProducts())
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.Name);
    System.Console.WriteLine(item.Price);
    System.Console.WriteLine(item.DateOfCreation);
    System.Console.WriteLine("------------------------");
}
System.Console.WriteLine();


System.Console.Write("All products : ");
System.Console.WriteLine(productServ.CountAllProducts());
System.Console.WriteLine();

var pr1 = productServ.SearchProductsByDateOfCreation(new DateTime(2024, 01, 01));
foreach (var item in pr1)
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.Name);
    System.Console.WriteLine(item.Price);
    System.Console.WriteLine(item.DateOfCreation);
}

var customerServ = new CustomerService();
var customerr = customerServ.GetAllCustomersByAge(20);
foreach (var item in customerr)
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
}


System.Console.WriteLine();

var custEmail = customerServ.GetCustomerByEmail("mustafo@gmail.com");
System.Console.WriteLine(custEmail.Id);
System.Console.WriteLine(custEmail.FullName);
System.Console.WriteLine(custEmail.Age);
System.Console.WriteLine(custEmail.Email);

System.Console.WriteLine();

System.Console.WriteLine(customerServ.CountAllCustomers());
System.Console.WriteLine();


var countryServ = new CountryService();
foreach (var item in countryServ.GetCountryies())
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.Name);
}
System.Console.WriteLine();

var countryName = countryServ.SearchCountryByName("France");
System.Console.WriteLine(countryName.Id);
System.Console.WriteLine(countryName.Name);
System.Console.WriteLine();

var countryId = countryServ.SearchCountryById(4);
System.Console.WriteLine(countryId.Id);
System.Console.WriteLine(countryId.Name);
System.Console.WriteLine();

System.Console.WriteLine(countryServ.CountAllCountries());


var orderServ = new OrderService();

foreach (var item in orderServ.GetOrders())
{
    System.Console.WriteLine(item.Description);
    System.Console.WriteLine(item.OrderTime);
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
    System.Console.WriteLine(item.CountryName);
    System.Console.WriteLine(item.ProductName);
    System.Console.WriteLine(item.Price);
    System.Console.WriteLine(item.DateOfCreation);
    System.Console.WriteLine("--------------------");
}

foreach (var item in orderServ.SearchOrdersByDateTime(new DateTime(2024, 01, 01)))
{
    System.Console.WriteLine(item.Description);
    System.Console.WriteLine(item.OrderTime);
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
    System.Console.WriteLine(item.CountryName);
    System.Console.WriteLine(item.ProductName);
    System.Console.WriteLine(item.Price);
    System.Console.WriteLine(item.DateOfCreation);
    System.Console.WriteLine("--------------------");
}

foreach (var item in orderServ.TenPopularOrders())
{
    System.Console.Write("All orders of customer : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine(item.ProductName);
    System.Console.WriteLine(item.Price);
    System.Console.WriteLine(item.DateOfCreation);
    System.Console.WriteLine("--------------------");
}
System.Console.WriteLine();
foreach (var item in orderServ.CountOfCustomersOrders())
{
    System.Console.Write("All orders of customer : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
    System.Console.WriteLine("--------------------");
}

System.Console.WriteLine();
foreach (var item in orderServ.CountMonthOrdersOfCountry())
{
    System.Console.WriteLine(item.CountryName);
    System.Console.Write("All orders of country during last month : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine("--------------------");
}

System.Console.WriteLine();
foreach (var item in orderServ.CountYearOrdersOfCountry())
{
    System.Console.WriteLine(item.CountryName);
    System.Console.Write("All orders of country during last month : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine("--------------------");
}

System.Console.WriteLine();


foreach (var item in orderServ.BestCustomerOfMonth())
{
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
    System.Console.Write("All orders of customer : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine("--------------------");
}
System.Console.WriteLine();
foreach (var item in orderServ.BestCustomerOfYear())
{
    System.Console.WriteLine(item.FullName);
    System.Console.WriteLine(item.Age);
    System.Console.WriteLine(item.Email);
    System.Console.Write("All orders of customer : ");
    System.Console.WriteLine(item.Count);
    System.Console.WriteLine("--------------------");
}