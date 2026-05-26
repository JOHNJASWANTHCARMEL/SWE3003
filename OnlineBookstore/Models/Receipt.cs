namespace OnlineBookstore.Models;

public class Receipt
{
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
}