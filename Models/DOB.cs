using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class DOBAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime now = DateTime.Now;
            DateTime DOB = DateTime.Parse(value.ToString());
            int age = now.Year - DOB.Year;
            if (DOB > now) 
            {
                return new ValidationResult("Invalid date of birth!");
            }
            if ( age < 18 )
            {
                return new ValidationResult("The chef must be at least 18 years old!");
            }
            else
                return ValidationResult.Success;
        }
    }
}