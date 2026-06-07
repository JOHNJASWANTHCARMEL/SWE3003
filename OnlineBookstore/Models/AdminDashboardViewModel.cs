namespace OnlineBookstore.Models;

public class AdminDashboardViewModel
{
    public List<Book> Books { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public AdminBookViewModel AddBookForm { get; set; } = new();
}
