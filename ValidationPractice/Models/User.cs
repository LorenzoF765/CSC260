using System.ComponentModel.DataAnnotations;
using ValidationPractice.Validators;

namespace ValidationPractice.Models
{
    [Address]
    public class User
    {
        [Required(ErrorMessage = "Name is required. Please enter a name that is not blank or null.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(5, 110, ErrorMessage = "Your age must be between 5 and 110")]
        public int? Age { get; set; } = null;

        public string? StreetName { get; set; } = null;
        public string? City { get; set; } = null;
        public string? ZipCode { get; set; } = null;
        public string? State { get; set; } = null;

    }
}
