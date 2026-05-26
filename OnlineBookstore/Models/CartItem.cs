namespace OnlineBookstore.Models;

public class CartItem
{
    public Book Book { get; set; }
    public int Quantity {get; set; }

    public decimal SubTotal()
    {
        return Book.Price * Quantity;
    }
}