using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address (e.g. name@domain.com).")]
    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Address { get; set; } = "";

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = "";
}
