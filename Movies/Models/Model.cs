using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.ComponentModel.DataAnnotations;

using Movies.Validators;

namespace Movies.Models{

    [atezAttribute]
    
    public class Movie{

        private static int nextId = 0;
        public int? Id { get; set; } = nextId++; //? means it can be nullable

        [Required(ErrorMessage = "You need a title dumb ass!")]

        [MaxLength(40)]

        public string Title { get; set; }

        [Required(ErrorMessage = "that's a fake year dumb ass!")]

        [Range(1888, 2023)]

        public int Year { get; set; }

        [Required(ErrorMessage = "this is a 5 start sytem dumb ass")]

		[Range(1, 5)]

		public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Image { get; set; }

        public string? Genre { get; set; }

        public Movie(){ }

        public Movie(string title, int year, float rating){

            this.Title = title;

            this.Year = year;

            this.Rating = rating;

        }

        public override string ToString(){

            return $"{Title} - {Year} - {Rating} stars";

        }



    }

}
