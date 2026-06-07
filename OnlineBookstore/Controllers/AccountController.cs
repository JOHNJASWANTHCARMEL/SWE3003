using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data;
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

        var customer = FakeDatabase.Customers.FirstOrDefault(c =>
            c.Account.Username == account.Username && c.Account.Password == account.Password);

        if (customer == null)
        {
            ViewBag.Error = "Invalid username or password. Please check your credentials or register.";
            return View(account);
        }

        HttpContext.Session.SetString("UserRole", "Customer");
        HttpContext.Session.SetString("Username", customer.FullName);
        return RedirectToAction("Index", "Book");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (FakeDatabase.Customers.Any(c => c.Account.Username == model.Username))
        {
            ModelState.AddModelError("Username", "This username is already taken.");
            return View(model);
        }

        var customer = new Customer
        {
            Id = FakeDatabase.Customers.Count + 1,
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            Account = new CustomerAccount
            {
                Username = model.Username,
                Password = model.Password
            }
        };

        FakeDatabase.Customers.Add(customer);
        return RedirectToAction("RegisterSuccess");
    }

    [HttpGet]
    public IActionResult RegisterSuccess()
    {
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}