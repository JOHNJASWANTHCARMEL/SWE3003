namespace OnlineBookstore.Models;

public class Shipment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public DateTime ShippedDate { get; set; } = DateTime.Now;
    public string Carrier { get; set; } = "Standard Post";
    public string TrackingNumber { get; set; } = "";
}
