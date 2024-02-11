using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class LoginUserViewModel
    {
        public string UserNAme { get; set; }
        
        [DataType(DataType.Password)]
        public string  PAssword { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
