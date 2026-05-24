using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

public class BookController : Controller
{
    public IActionResult Index()
    {
        var books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert Martin",
                Price = 30
            }
        };

        return View(books);
    }
}