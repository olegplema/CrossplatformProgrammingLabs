using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class SignUpViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
    [RegularExpression(@"^[a-zA-Z0-9._-]+$", ErrorMessage = "Username can only contain letters, numbers, dots, underscores, and hyphens")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Full name is required")]
    [StringLength(500, ErrorMessage = "Full name cannot be longer than 500 characters")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = default!;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Please enter exactly 9 digits for the phone number")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = default!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [Required(ErrorMessage = "Please confirm your password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = default!;
}
