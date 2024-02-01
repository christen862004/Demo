using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    /*
     minlength - requrired - range (2000,20000) - patter "RgExpre" - maxLength -min -max....
     */
    public class Employee
    {
        public int Id { get; set; }

        [Unique]
        [MinLength(3,ErrorMessage ="Name Must BE More Than 2 Char")]
        [MaxLength(25,ErrorMessage ="Name Must Be Less Than 25 Char")]
        public string Name { get; set; }

        [Range(30,65,ErrorMessage ="Age Must be with in range 30 to 65")]
        public int Age { get; set; }

        [Display(Name="Emp Address")]
        //[DataType(DataType.Password)]
        [RegularExpression("(Alex|Cairo|Monf)",ErrorMessage ="Address Must be Alex or Cairo or Monf")]
        public string Address { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must be jpg or png only")]
        public string Image { get; set; }

        //[MoreThan(MaxVal = 3000)]
        [Remote("CheckSalary","Employee"
            , AdditionalFields = "Age"
            , ErrorMessage ="Salary Must be More Than 2000")]//Logic
        public int Salary { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentID { get; set; }

        public Department? Department { get; set; }/*null*/
    }
}
