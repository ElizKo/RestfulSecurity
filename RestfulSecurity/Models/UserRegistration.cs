using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RestfulSecurity.Models
{
    public class UserRegistration
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}