namespace OnlineBookstore.Models;

public class Book
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    // Stores the image URL used by the frontend book cards and details page.
    public string ImageUrl { get; set; } = "";

    public BookSpecification Specification { get; set; } = new BookSpecification();
    public InventoryStatus Inventory { get; set; } = new InventoryStatus();
}