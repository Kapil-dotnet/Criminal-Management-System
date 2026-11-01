using System.ComponentModel.DataAnnotations;

namespace CriminalManagementSystem.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Confirm password should match the password.")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression("^[6-9]\\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
        public string? Mobile { get; set; }
    }
}