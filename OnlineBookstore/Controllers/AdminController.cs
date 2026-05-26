using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;

namespace OnlineBookstore.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View(FakeDatabase.Books);
    }
}