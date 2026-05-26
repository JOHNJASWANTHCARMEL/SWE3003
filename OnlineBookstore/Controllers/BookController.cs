using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;

namespace OnlineBookstore.Controllers;

public class BookController : Controller
{
    public IActionResult Index()
    {
        return View(FakeDatabase.Books);
    }
}