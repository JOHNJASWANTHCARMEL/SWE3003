namespace OnlineBookstore.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public Invoice Invoice { get; set; } = new Invoice();
    public string Status { get; set; } = "Paid";
    public Package? Package { get; set; }
    public Shipment? Shipment { get; set; }

    public decimal Total()
    {
        return Items.Sum(i => i.PurchasePrice * i.Quantity);
    }
}