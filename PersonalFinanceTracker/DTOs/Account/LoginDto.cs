using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.DTOs.Account
{
    public class LoginDto
    {

        [Required]
        public string Email { get; set; }=string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
