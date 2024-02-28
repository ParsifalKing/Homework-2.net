namespace Domain.Models;

public class BookInfo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Access { get; set; }
    public string CategoryName { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Count { get; set; }
}
