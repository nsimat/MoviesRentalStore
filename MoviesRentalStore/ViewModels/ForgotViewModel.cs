using System.ComponentModel.DataAnnotations;

namespace MoviesRentalStore.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}