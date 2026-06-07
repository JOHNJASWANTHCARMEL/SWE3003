using OnlineBookstore.Models;

namespace OnlineBookstore.Data;

public static class FakeDatabase
{
    // This fake database is used as sample storage for the prototype.
    // Books added or removed by the admin are updated in this list while the app is running.
    public static List<Book> Books = new()
    {
        new Book
        {
            Id = 1,
            Price = 39.99m,
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg",
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
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780201633610-L.jpg",
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
        },
        new Book
        {
            Id = 3,
            Price = 44.99m,
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780201616224-L.jpg",
            Specification = new BookSpecification
            {
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt and David Thomas",
                Publisher = "Addison-Wesley"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 8
            }
        },
        new Book
        {
            Id = 4,
            Price = 59.99m,
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780131103627-L.jpg",
            Specification = new BookSpecification
            {
                Title = "The C Programming Language",
                Author = "Brian Kernighan and Dennis Ritchie",
                Publisher = "Prentice Hall"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 6
            }
        },
        new Book
        {
            Id = 5,
            Price = 69.99m,
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780262033848-L.jpg",
            Specification = new BookSpecification
            {
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                Publisher = "MIT Press"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 4
            }
        },
        new Book
        {
            Id = 6,
            Price = 34.99m,
            ImageUrl = "https://covers.openlibrary.org/b/isbn/9780134685991-L.jpg",
            Specification = new BookSpecification
            {
                Title = "Effective Java",
                Author = "Joshua Bloch",
                Publisher = "Addison-Wesley"
            },
            Inventory = new InventoryStatus
            {
                StockQuantity = 7
            }
        }
    };

    public static ShoppingCart Cart = new ShoppingCart();

    public static List<Customer> Customers = new();

    // Generates the next available book ID when admin adds a new book.
    public static int GetNextBookId()
    {
        if (Books.Count == 0)
        {
            return 1;
        }

        return Books.Max(book => book.Id) + 1;
    }
}