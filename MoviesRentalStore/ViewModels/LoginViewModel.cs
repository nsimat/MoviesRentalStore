using System.ComponentModel.DataAnnotations;

namespace MoviesRentalStore.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember the password ?")]
        public bool RememberMe { get; set; }
    }
}