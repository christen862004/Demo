using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UniqueAttribute:ValidationAttribute//Server Side C# ModelState
    {
        public int xyz { get; set; }//>< %

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            //  Employee EmpFromRequest = validationContext.ObjectInstance as Employee;


            ITIContext context = validationContext.GetService<ITIContext>();

            Employee Emp=
                context.Employees
                .FirstOrDefault(e => e.Name == value.ToString());
            if(Emp == null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist");
        }
    }
}
