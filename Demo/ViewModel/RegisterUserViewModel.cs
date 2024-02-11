using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm and password not matching")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }


    }
}
