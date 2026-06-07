namespace OnlineBookstore.Models;

public class ShoppingCart
{
    public List<CartItem> Items { get; set; } = new();

    public void AddItem(Book book)
    {
        var existingItem = Items.FirstOrDefault(i => i.Book.Id == book.Id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            Items.Add(new CartItem { Book = book, Quantity = 1 });
        }
    }

    public void RemoveItem(int bookId)
    {
        Items.RemoveAll(i => i.Book.Id == bookId);
    }

    public void IncreaseQuantity(int bookId)
    {
        var item = Items.FirstOrDefault(i => i.Book.Id == bookId);
        if (item != null) item.Quantity++;
    }

    public void DecreaseQuantity(int bookId)
    {
        var item = Items.FirstOrDefault(i => i.Book.Id == bookId);
        if (item == null) return;
        item.Quantity--;
        if (item.Quantity <= 0) Items.Remove(item);
    }

    public decimal GetTotal()
    {
        return Items.Sum(i => i.SubTotal());
    }
}