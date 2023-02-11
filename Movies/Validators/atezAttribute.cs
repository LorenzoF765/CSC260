using Movies.Models;

using System.ComponentModel.DataAnnotations;

namespace Movies.Validators{ 

	public class atezAttribute : ValidationAttribute{

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext){

			var movie = (Movie)validationContext.ObjectInstance;

			if(movie.Year >= 1980 && movie.Year < 1990 && movie.Rating < 3){

				return new ValidationResult("there are no movies lower than a 3 in the 80's");
			
			}else{

				return ValidationResult.Success;

			}

		}

	}

}
