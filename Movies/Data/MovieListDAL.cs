using Movies.Models;
using Movies.Interfaces;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        // moved from the controller
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Lion King", 1994, 3.6f),
            new Movie("Trip to the Moon", 1902, 4.1f),
            new Movie("Megamind", 2010, 6.0f)
        };

        public void AddMovie(Movie movie)
        {
            MovieList.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            MovieList[GetMovie(movie)] = movie;
        }

        public Movie GetMovie(int? id)
        {
            return MovieList.Where(m => m.Id == id).FirstOrDefault();
        }

        public int GetMovie(Movie m)
        {
            return MovieList.FindIndex(x =>x.Id == m.Id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieList;
        }

        public void RemoveMovie(int? id)
        {
            Movie found = GetMovie(id);
            MovieList.Remove(found);
        }
    }
}
