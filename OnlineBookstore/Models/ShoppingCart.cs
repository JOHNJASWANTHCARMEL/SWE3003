using System.Security.Cryptography.X509Certificates;

namespace OnlineBookstore.Models;

public class ShoppingCart
{
    public List<CartItem> Items {get; set; } = new();

    public void AddItem(Book book)
    {
        var existingItem = Items.FirstOrDefault(i => i.Book.Id == book.Id);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            Items.Add(new CartItem
            {
                Book = book,
                Quantity = 1
            });
        }
    }

    public decimal GetTotal()
    {
        return Items.Sum(i => i.SubTotal());
    }
}