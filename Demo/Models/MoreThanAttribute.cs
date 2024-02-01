using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    //Custom attribute check 
    public class MoreThanAttribute:ValidationAttribute
    {
        public int MaxVal { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int val =int.Parse(value.ToString());
            if (val > MaxVal)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Value Must be More Than {MaxVal}");
        }
    }
}
