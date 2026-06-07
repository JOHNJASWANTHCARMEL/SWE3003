using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class CheckoutController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        if (FakeDatabase.Cart.Items.Count == 0)
        {
            return RedirectToAction("Index", "Cart");
        }

        return View(FakeDatabase.Cart);
    }

    [HttpGet]
    public IActionResult Pay()
    {
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public IActionResult Pay(string cardName, string creditCardNumber, string deliveryAddress, string phoneNumber, bool simulateFailure = false)
    {
        if (FakeDatabase.Cart.Items.Count == 0)
        {
            return RedirectToAction("Index", "Cart");
        }

        if (string.IsNullOrWhiteSpace(cardName) ||
            string.IsNullOrWhiteSpace(creditCardNumber) ||
            string.IsNullOrWhiteSpace(deliveryAddress) ||
            string.IsNullOrWhiteSpace(phoneNumber))
        {
            ViewBag.Error = "Please complete all checkout fields.";
            return View("Index", FakeDatabase.Cart);
        }

        if (simulateFailure)
        {
            return View("Failed");
        }

        Payment payment = new Payment();
        bool success = payment.ProcessPayment(FakeDatabase.Cart.GetTotal());

        if (success)
        {
            var orderId = FakeDatabase.GetNextOrderId();
            var order = new Order
            {
                Id = orderId,
                Status = "Paid",
                Items = FakeDatabase.Cart.Items.Select(i => new OrderItem
                {
                    Book = i.Book,
                    Quantity = i.Quantity,
                    PurchasePrice = i.Book.Price
                }).ToList(),
                Invoice = new Invoice
                {
                    InvoiceNumber = orderId,
                    TotalAmount = FakeDatabase.Cart.GetTotal(),
                    CreatedDate = DateTime.Now
                }
            };
            FakeDatabase.Orders.Add(order);

            Receipt receipt = new Receipt
            {
                AmountPaid = FakeDatabase.Cart.GetTotal()
            };

            FakeDatabase.Cart.Items.Clear();

            return View("Success", receipt);
        }

        return View("Failed");
    }
}