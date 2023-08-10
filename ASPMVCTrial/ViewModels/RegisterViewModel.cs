using System.ComponentModel.DataAnnotations;

namespace ASPMVCTrial.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name = "ConfirmPassword")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
