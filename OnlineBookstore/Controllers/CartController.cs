using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;

namespace OnlineBookstore.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View(FakeDatabase.Cart);
    }

    public IActionResult Add(int id)
    {
        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book != null && book.Inventory.IsInStock())
        {
            FakeDatabase.Cart.AddItem(book);
        }

        return RedirectToAction("Index", "Book");
    }

    public IActionResult BuyNow(int id)
    {
        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book != null && book.Inventory.IsInStock())
        {
            FakeDatabase.Cart.AddItem(book);
        }

        return RedirectToAction("Index", "Checkout");
    }

    public IActionResult Clear()
    {
        FakeDatabase.Cart.Items.Clear();
        return RedirectToAction("Index");
    }
}