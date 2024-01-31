using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UserAccount
    {
        public string UserNAme { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
