using System.ComponentModel.DataAnnotations;

namespace NewsBoardBE.Modals
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}