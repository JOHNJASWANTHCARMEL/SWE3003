using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class CheckoutController : Controller
{
    public IActionResult Pay()
    {
        Payment payment = new Payment();

        bool success = payment.ProcessPayment(100);

        if (success)
        {
            Receipt receipt = new Receipt
            {
                AmountPaid = 100
            };
            
            return View("Success", receipt);
        }

        return View("Failed");
    }
}