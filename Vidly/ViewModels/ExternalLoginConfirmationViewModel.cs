using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
