using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;

namespace OnlineBookstore.Controllers;

public class BookController : Controller
{
    public IActionResult Index()
    {
        return View(FakeDatabase.Books);
    }

    // Shows the details page for the selected book.
    public IActionResult Details(int id)
    {
        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }
}