using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class AdminController : Controller
{
    private bool IsAdmin() => HttpContext.Session.GetString("UserRole") == "Admin";

    private AdminDashboardViewModel BuildDashboard() => new AdminDashboardViewModel
    {
        Books = FakeDatabase.Books,
        Orders = FakeDatabase.Orders
    };

    public IActionResult Dashboard()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        return View(BuildDashboard());
    }

    [HttpPost]
    public IActionResult AddBook(AdminBookViewModel model)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        if (!ModelState.IsValid)
        {
            var vm = BuildDashboard();
            vm.AddBookForm = model;
            return View("Dashboard", vm);
        }

        FakeDatabase.Books.Add(new Book
        {
            Id = FakeDatabase.GetNextBookId(),
            Price = model.Price,
            ImageUrl = model.ImageUrl,
            Specification = new BookSpecification
            {
                Title = model.Title,
                Author = model.Author,
                Publisher = model.Publisher
            },
            Inventory = new InventoryStatus { StockQuantity = model.StockQuantity }
        });

        TempData["FlashSuccess"] = $"'{model.Title}' has been added to the catalogue.";
        return RedirectToAction("Dashboard");
    }

    [HttpGet]
    public IActionResult EditBook(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return RedirectToAction("Dashboard");

        return View(new AdminBookViewModel
        {
            Id = book.Id,
            Title = book.Specification.Title,
            Author = book.Specification.Author,
            Publisher = book.Specification.Publisher,
            Price = book.Price,
            StockQuantity = book.Inventory.StockQuantity,
            ImageUrl = book.ImageUrl
        });
    }

    [HttpPost]
    public IActionResult EditBook(AdminBookViewModel model)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        if (!ModelState.IsValid) return View(model);

        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == model.Id);
        if (book == null) return RedirectToAction("Dashboard");

        book.Specification.Title = model.Title;
        book.Specification.Author = model.Author;
        book.Specification.Publisher = model.Publisher;
        book.Price = model.Price;
        book.Inventory.StockQuantity = model.StockQuantity;
        book.ImageUrl = model.ImageUrl;

        TempData["FlashSuccess"] = $"'{model.Title}' has been updated.";
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    public IActionResult RemoveBook(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        var book = FakeDatabase.Books.FirstOrDefault(b => b.Id == id);
        if (book != null) FakeDatabase.Books.Remove(book);

        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    public IActionResult ProcessFulfilment(int orderId)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        var order = FakeDatabase.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null || order.Status != "Paid") return RedirectToAction("Dashboard");

        order.Package = new Package
        {
            Id = orderId,
            OrderId = orderId,
            PackedDate = DateTime.Now
        };

        order.Shipment = new Shipment
        {
            Id = orderId,
            OrderId = orderId,
            ShippedDate = DateTime.Now,
            Carrier = "Standard Post",
            TrackingNumber = $"TRK{orderId:D4}{DateTime.Now:MMddHHmm}"
        };

        order.Status = "Shipped";

        TempData["FlashSuccess"] = $"Order #{orderId} has been processed and marked as shipped.";
        return RedirectToAction("Dashboard");
    }
}