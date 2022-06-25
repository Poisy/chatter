using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Chatter.Models
{
    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "Username is mandatory!")]
        [MinLength(3)]
        [MaxLength(10)]
        public string Username{ get; set; }


        [Required(ErrorMessage = "Password is mandatory!")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{5,}", 
            ErrorMessage = "The password has to be at least 5 characters with at least 1 Upper Case character, 1 Lower Case character and 1 Number!")]
        public string ConfirmPassword{ get; set; }
    }
}