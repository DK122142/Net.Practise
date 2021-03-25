using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Requires username")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Requires password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string ConfirmPassword { get; set; }
    }
}
