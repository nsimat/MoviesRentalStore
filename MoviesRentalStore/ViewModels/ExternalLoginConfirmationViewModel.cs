using System.ComponentModel.DataAnnotations;

namespace MoviesRentalStore.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ID Card Number")]
        public string IdCardNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}