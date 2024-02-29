namespace Domain.Models;

public class Order
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime OrderTime { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int CountryId { get; set; }
}
