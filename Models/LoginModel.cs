using System.ComponentModel.DataAnnotations;

namespace WarOfRightsWeb.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool? Cookies { get; set; }

        public bool RememberMe { get; set; }
    }
}
