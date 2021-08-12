using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Services.Repository;
using Movies.Services.Services;
using System;

namespace Movies.Services.uTest.Services
{
    [TestClass]
    public class MovieServiceTest
    {
        private readonly IMovieRepository movieRepo;
        public MovieServiceTest()
        {            
            Environment.SetEnvironmentVariable("DB_PATH", "D:\\mine\\practice\\Backend\\MoviesApp\\movies.json");
            this.movieRepo = new InMemoryMovieRepository();
        }

        [TestMethod]
        public void GetMovie_Should_Return_Movie_If_MovieId_IsValid()
        {
            //setup
            var movieId = "tt0068646";
            var movieService = new MovieService(this.movieRepo);

            //Act
            var movie = movieService.GetMovie(movieId);

            Assert.IsNotNull(movie);
            Assert.AreEqual(movieId, movie.ImdbID);
        }

        [TestMethod]
        public void GetMovie_Should_Return_Null_If_MovieId_Invalid()
        {
            //setup
            var movieId = "random";
            var movieService = new MovieService(this.movieRepo);

            //Act
            var movie = movieService.GetMovie(movieId);

            Assert.IsNull(movie);
        }

        [TestMethod]
        public void GetMovies_Should_Return_All_Movies()
        {
            //setup
            var count = 10;
            var movieService = new MovieService(movieRepo);

            //Act
            var movies = movieService.GetMovies();

            Assert.AreEqual(count, movies.Count);
        }

        [TestMethod]
        public void GetMovies_Should_Return_Only_Those_Movies_For_Which_Language_Is_Given()
        {
            //setup
            var language = "ENGLISH";
            var movieService = new MovieService(movieRepo);

            //Act
            var movies = movieService.GetMovies(null, language);

            foreach (var movie in movies)
            {
                Assert.AreEqual(language, movie.Language);
            }
        }

        [TestMethod]
        public void GetMovies_Should_Return_Only_Those_Movies_For_Which_Location_Is_Given()
        {
            //setup
            var location = "PUNE";
            var movieService = new MovieService(movieRepo);

            //Act
            var movies = movieService.GetMovies(location);

            foreach (var movie in movies)
            {
                Assert.AreEqual(location, movie.Location);
            }
        }
    }
}
