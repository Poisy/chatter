using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;

namespace Chatter.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is mandatory!")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is mandatory!")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{5,}", 
            ErrorMessage = "The password has to be at least 5 characters with at least 1 Upper Case character, 1 Lower Case character and 1 Number!")]
        public string Password{ get; set; }
    }
}