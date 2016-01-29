using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Craig.Validation
{
    public class CastValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cast = value as string[];

            if (cast != null && cast.Any(string.IsNullOrEmpty))
                return new ValidationResult("Cast cannot contain blank cast members.");

            return null;
        }
    }
}