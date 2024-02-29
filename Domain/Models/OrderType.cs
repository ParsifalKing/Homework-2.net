namespace Domain.Models;

public class OrderType
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime OrderTime { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string CountryName { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    public DateTime DateOfCreation { get; set; }
    public int Count { get; set; }
}
