using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [Display(Name="Emp Address")]
        //[DataType(DataType.Password)]
        public string Address { get; set; }
        
        public string Image { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
    }
}
