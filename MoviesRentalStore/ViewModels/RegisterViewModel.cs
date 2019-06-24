using System.ComponentModel.DataAnnotations;

namespace MoviesRentalStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The string {0} must have at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password ")]
        [Compare("Password", ErrorMessage = "Password and password confirmation don't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "ID Card Number")]
        public string IdCardNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}