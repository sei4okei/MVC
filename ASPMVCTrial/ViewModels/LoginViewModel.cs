using System.ComponentModel.DataAnnotations;

namespace ASPMVCTrial.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
