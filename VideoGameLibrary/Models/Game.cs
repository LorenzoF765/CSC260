using System.ComponentModel.DataAnnotations;

namespace VideoGameLibrary.Models
{
    public class Game
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Your game must have a title.")]
        [MaxLength(255)]
        public string Title { get; set; } = "[NO TITLE]";
        [MaxLength(255)]
        [Required(ErrorMessage = "Your game must have a platform.")]
        public string Platform { get; set; } = string.Empty;
        [MaxLength(255)]
        [Required(ErrorMessage = "Your game must have a genere.")]
        public string Genere { get; set; } = string.Empty;
        public string ESRB { get; set; } = "RP";
        [Required(ErrorMessage = "Release Year is required.")]
        [Range(1958, 2023, ErrorMessage = "No games were released in that year.")]
        public int ReleaseYear { get; set; } = 1958;
        [Required(ErrorMessage = "Your game must have an image link.")]
        public string ImageName { get; set; } = string.Empty;
        public string? LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } = null;

        public Game() { }

        public Game(string Title, string Platform, string Genere, string ESRB, int ReleaseYear, string ImageName)
        { 
            this.Title = Title;
            this.Platform = Platform;
            this.Genere = Genere;
            this.ESRB = ESRB;
            this.ReleaseYear = ReleaseYear;
            this.ImageName = ImageName;
        }

        public Game(string Title, string Platform, string Genere, string ESRB, int ReleaseYear, string ImageName, string LoanedTo, DateTime LoanDate)
        {
            this.Title = Title;
            this.Platform = Platform;
            this.Genere = Genere;
            this.ESRB = ESRB;
            this.ReleaseYear = ReleaseYear;
            this.ImageName = ImageName;
            this.LoanedTo = LoanedTo;
            this.LoanDate = LoanDate;
        }

        public void Loan(string? name = null)
        {
            if (name != null)
            { 
                LoanedTo = name;
                LoanDate = DateTime.Now;
            }
            else if(LoanedTo != null) 
            {
                LoanedTo = null;
                LoanDate = null;
            }
        }
    }
}
