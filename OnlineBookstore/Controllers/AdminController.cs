using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class AdminController : Controller
{
    // Only admin users should be able to access this dashboard.
    public IActionResult Dashboard()
    {
        string? role = HttpContext.Session.GetString("UserRole");

        if (role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        return View(FakeDatabase.Books);
    }

    // Adds a new book from the admin dashboard form.
    [HttpPost]
    public IActionResult AddBook(string title, string author, string publisher, decimal price, int stockQuantity, string imageUrl)
    {
        string? role = HttpContext.Session.GetString("UserRole");

        if (role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        Book newBook = new Book
        {
            Id = FakeDatabase.GetNextBookId(),
            Price = price,
            ImageUrl = imageUrl,
            Specification = new BookSpecification
            {
                Title = title,
                Author = author,
                Publisher = publisher
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = stockQuantity
            }
        };

        FakeDatabase.Books.Add(newBook);

        return RedirectToAction("Dashboard");
    }

    // Removes a book using its ID.
    [HttpPost]
    public IActionResult RemoveBook(int id)
    {
        string? role = HttpContext.Session.GetString("UserRole");

        if (role != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);

        if (book != null)
        {
            FakeDatabase.Books.Remove(book);
        }

        return RedirectToAction("Dashboard");
    }
}