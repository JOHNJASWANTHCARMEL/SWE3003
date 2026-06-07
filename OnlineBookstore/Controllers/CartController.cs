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
        bool isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

        if (book == null)
        {
            if (isAjax) return Json(new { success = false, message = "Book not found." });
            return RedirectToAction("Index", "Book");
        }

        if (!book.Inventory.IsInStock())
        {
            if (isAjax) return Json(new { success = false, message = "Stock has run out!", newStock = 0 });
            return RedirectToAction("Index", "Book");
        }

        FakeDatabase.Cart.AddItem(book);
        book.Inventory.StockQuantity--;

        if (isAjax) return Json(new { success = true, message = "Added to cart!", newStock = book.Inventory.StockQuantity });
        return RedirectToAction("Index", "Book");
    }

    public IActionResult BuyNow(int id)
    {
        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book != null && book.Inventory.IsInStock())
        {
            FakeDatabase.Cart.AddItem(book);
            book.Inventory.StockQuantity--;
        }

        return RedirectToAction("Index", "Checkout");
    }

    public IActionResult Clear()
    {
        FakeDatabase.Cart.Items.Clear();
        return RedirectToAction("Index");
    }
}