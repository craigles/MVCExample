using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies;

namespace UnitTestProject1
{
    [TestClass]
    public class MovieRepositoryTests
    {
        public MovieRepository MovieRepository
        {
            get
            {
                return new MovieRepository();
            }
        }

        [TestMethod]
        public void GetAll_ShouldHaveAtLeast80Movies()
        {
            MovieRepository.GetAll()
                .Should()
                .HaveCount(count => count >= 80);
        }

        [TestMethod]
        public void GetById_ShouldHaveMovieHorribleBosses()
        {
            MovieRepository.GetById(22)
                .Should()
                .Match<Movie>(movie => movie.Title == "Horrible Bosses");
        }

        [TestMethod]
        public void Create_VerifySubsequentRequestsYieldAnIncrementingMovieId()
        {
            var movieRepository = MovieRepository;
            var movie = new Movie
            {
                Title = "Title",
                Cast = new[] { "someone" },
                Classification = "M15",
                Rating = 5,
                Genre = "Drama",
                ReleaseDate = 2014
            };

            var firstMovieId = movieRepository.Create(movie);
            var secondMovieId = movieRepository.Create(movie);

            secondMovieId
                .Should()
                .Be(firstMovieId + 1);
        }

        [TestMethod]
        public void Create_VerifyCreatingAMovieWithoutATitleThrowsError()
        {
            Action createMovieWithNoTitle = () => MovieRepository.Create(new Movie());

            createMovieWithNoTitle
                .ShouldThrow<Exception>()
                .WithMessage("Movie Title is mandatory");
        }
    }
}
