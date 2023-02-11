using ValidationPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace ValidationPractice.Validators
{
    public class AddressAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var User = (User)validationContext.ObjectInstance;

            if (User.StreetName == null && User.City == null && User.State == null && User.ZipCode == null)
            {
                return ValidationResult.Success;
            }
            if (User.StreetName != null && User.City != null && User.State != null && User.ZipCode != null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("All or none of the fields in the Address should filled.");
        }
    }
}
