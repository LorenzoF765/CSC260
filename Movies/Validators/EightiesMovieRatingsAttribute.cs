using Movies.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies.Validators
{
    public class EightiesMovieRatingsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.Year >= 1980 && movie.Year < 1990 && movie.Rating < 2.5f)
            {
                // it bad
                return new ValidationResult("Movies in the eighties were not bad.");
            }

            // we good
            return ValidationResult.Success;
        }
    }
}
