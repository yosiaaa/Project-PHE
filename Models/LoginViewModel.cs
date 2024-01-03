using System.ComponentModel.DataAnnotations;

namespace ProjectSupplyManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        
    }
}
