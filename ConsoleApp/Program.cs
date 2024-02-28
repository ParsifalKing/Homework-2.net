using Domain.Models;
using Infrastructure.Services;

try
{

    var bookAuthorSer = new BookAuthor_Service();
    foreach (var item in bookAuthorSer.GetBooks_Author())
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.WriteLine(item.FullName);
        System.Console.WriteLine(item.Age);
    }
    System.Console.WriteLine();

    foreach (var item in bookAuthorSer.CountAllAuthors_Books())
    {
        System.Console.WriteLine(item.FullName);
        System.Console.WriteLine(item.Access);
        System.Console.WriteLine(item.Age);
        System.Console.Write($"This author have books : ");
        System.Console.WriteLine(item.Count);
    }

    System.Console.WriteLine();

    foreach (var item in bookAuthorSer.CountAuthor_Books(1))
    {
        System.Console.WriteLine(item.FullName);
        System.Console.WriteLine(item.Access);
        System.Console.WriteLine(item.Age);
        System.Console.Write($"This author have books : ");
        System.Console.WriteLine(item.Count);
    }

    System.Console.WriteLine();
    foreach (var item in bookAuthorSer.CountBook_Author(1))
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.Write($"This book have authors : ");
        System.Console.WriteLine(item.Count);
    }

    foreach (var item in bookAuthorSer.CountAllBook_Author())
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.Write($"This book have authors : ");
        System.Console.WriteLine(item.Count);
    }

    var bookCategoryServ = new BookCategory_Service();

    foreach (var item in bookCategoryServ.GetBooks_Category())
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.WriteLine(item.CategoryName);
    }
    System.Console.WriteLine();


    foreach (var item in bookCategoryServ.CountAllCategory_Books())
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.Write("This book has categories : ");
        System.Console.WriteLine(item.Count);
    }
    System.Console.WriteLine();

    foreach (var item in bookCategoryServ.CountCategory_Books(1))
    {
        System.Console.WriteLine(item.Title);
        System.Console.WriteLine(item.Description);
        System.Console.WriteLine(item.Access);
        System.Console.Write("This book has categories : ");
        System.Console.WriteLine(item.Count);
    }
    System.Console.WriteLine();


    foreach (var item in bookCategoryServ.CountAllBook_Categories())
    {
        System.Console.Write("Name of Category : ");
        System.Console.WriteLine(item.CategoryName);
        System.Console.Write("This category has books : ");
        System.Console.WriteLine(item.Count);
    }
    System.Console.WriteLine();

    foreach (var item in bookCategoryServ.CountBook_Categories(1))
    {
        System.Console.Write("Name of Category : ");
        System.Console.WriteLine(item.CategoryName);
        System.Console.Write("This category has books : ");
        System.Console.WriteLine(item.Count);
    }
    System.Console.WriteLine();


    var bookServ = new BookService();
    foreach (var item in bookServ.CountAllBooks())
    {
        System.Console.Write("The count of all books are : ");
        System.Console.WriteLine(item.Count);
    }
}
catch (System.Exception)
{
    System.Console.WriteLine("Ups warning!!!");

}
