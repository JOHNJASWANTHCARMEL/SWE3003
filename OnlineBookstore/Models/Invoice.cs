namespace OnlineBookstore.Models;

public class Invoice
{
    public int InvoiceNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}