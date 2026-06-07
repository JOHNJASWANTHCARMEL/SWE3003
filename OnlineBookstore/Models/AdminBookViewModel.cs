using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models;

public class AdminBookViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Author is required.")]
    public string Author { get; set; } = "";

    public string Publisher { get; set; } = "";

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
    public int StockQuantity { get; set; }

    public string ImageUrl { get; set; } = "";
}
