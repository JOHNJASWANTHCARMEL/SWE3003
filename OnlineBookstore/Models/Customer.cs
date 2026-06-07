namespace OnlineBookstore.Models;

public class Customer : User
{
    public CustomerAccount Account { get; set; } = new CustomerAccount();
}