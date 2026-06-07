namespace OnlineBookstore.Models;

public class Package
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public DateTime PackedDate { get; set; } = DateTime.Now;
}
