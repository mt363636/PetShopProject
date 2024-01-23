using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Attributes
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int age)
            {
                if (age <= 0)
                {
                    return new ValidationResult("Age must be a positive number");
                }
                if (age > 50)
                {
                    return new ValidationResult("Age is too big");
                }
            }
            return ValidationResult.Success;
        }
    }

}
