namespace OnlineBookstore.Models;

public class InventoryStatus
{
    public int StockQuantity { get; set; }
    public bool IsInStock()
    {
        return StockQuantity > 0;
    }
}