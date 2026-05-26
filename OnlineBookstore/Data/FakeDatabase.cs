using OnlineBookstore.Models;

namespace OnlineBookstore.Data;

public static class FakeDatabase
{
    public static List<Book> Books = new()
    {
        new Book
        {
            Id = 1,
            Price = 39.99m,
            Specification = new BookSpecification
            {
                Title = "Clean Code",
                Author = "Robert Martin",
                Publisher = "Prentice Hall"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 10
            }
        },
        new Book
        {
            Id = 2,
            Price = 49.99m,
            Specification = new BookSpecification
            {
                Title = "Design Patterns",
                Author = "Gang of Four",
                Publisher = "Addison-Wesley"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 5
            }
        }
    };
}