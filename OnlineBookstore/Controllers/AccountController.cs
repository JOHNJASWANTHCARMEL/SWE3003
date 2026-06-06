using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(CustomerAccount account, string accountType)
    {
        if (string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Password))
        {
            ViewBag.Error = "Please enter username and password.";
            return View(account);
        }

        if (accountType == "Admin")
        {
            HttpContext.Session.SetString("UserRole", "Admin");
            HttpContext.Session.SetString("Username", account.Username);

            return RedirectToAction("Dashboard", "Admin");
        }

        HttpContext.Session.SetString("UserRole", "Customer");
        HttpContext.Session.SetString("Username", account.Username);

        return RedirectToAction("Index", "Book");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}