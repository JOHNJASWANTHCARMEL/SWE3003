namespace OnlineBookstore.Models;

public class Book
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public BookSpecification Specification { get; set; }
    public InventoryStatus Inventory { get; set; }
}