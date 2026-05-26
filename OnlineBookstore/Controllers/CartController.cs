using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class CartController : Controller
{
    private static ShoppingCart cart = new ShoppingCart();

    public IActionResult Index()
    {
        return View(cart);
    }

    public IActionResult Add(int id)
    {
        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book != null && book.Inventory.IsInStock())
        {
            cart.AddItem(book);
        }

        return RedirectToAction("Index", "Book");
    }
}