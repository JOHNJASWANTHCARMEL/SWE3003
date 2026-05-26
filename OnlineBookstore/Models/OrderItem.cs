namespace OnlineBookstore.Models;

public class OrderItem
{
    public Book Book { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
}