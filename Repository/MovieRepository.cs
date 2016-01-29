using System.Collections.Generic;
using Movies;

namespace Repository
{
    public class MovieRepository : IMovieRepository
    {
        public int Create(Movie movie)
        {
            return 1;
        }

        public List<Movie> GetAll()
        {
            var movies = new List<Movie>();
            for (var i = 1; i <= 77; i++)
            {
                var movie = new Movie
                {
                    MovieId = i,
                    Cast = new[] { "Craig", "Someone else" },
                    Classification = "M15",
                    Genre = "Horror",
                    Rating = 5,
                    ReleaseDate = 2001,
                    Title = "Movie " + i
                };
                movies.Add(movie);
            }
            return movies;
        }

        public Movie GetById(int id)
        {
            return new Movie
            {
                MovieId = id,
                Cast = new[] {"Craig", "Someone else"},
                Classification = "M15",
                Genre = "Horror",
                Rating = 5,
                ReleaseDate = 2001,
                Title = "Movie "
            };
        }

        public void Update(Movie movie)
        {
            
        }
    }
}
