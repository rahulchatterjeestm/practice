using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Models.Models;
using Movies.Services.Services;
using Movies.WebApi.Controllers;
using System.Collections.Generic;

namespace Movies.WebApi.uTest.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
        private readonly Mock<IMovieService> mockMovieService;
        private readonly Mock<ILogger<MoviesController>> mockLogger;

        public MoviesControllerTest()
        {
            this.mockMovieService = new Mock<IMovieService>();
            this.mockLogger = new Mock<ILogger<MoviesController>>();
        }

        [TestMethod]
        public void GetMovies_Should_Return_All_Movies()
        {
            var webApi = new MoviesController(this.mockLogger.Object, this.mockMovieService.Object);

            //setup
            this.mockMovieService.Setup(x => x.GetMovies(It.IsAny<string>(), It.IsAny<string>()))
                                .Returns(new List<Movie> 
                                { 
                                    new Movie
                                    {
                                        ImdbID = "id"
                                    }
                                });

            var result = webApi.GetAllMovies("location", "language");

            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public void GetMovie_Should_Return_Movie_Of_Given_Id()
        {
            var webApi = new MoviesController(this.mockLogger.Object, this.mockMovieService.Object);
            var movieId = "1";

            //setup
            this.mockMovieService.Setup(x => x.GetMovie(movieId))
                                .Returns(new MovieDetail
                                {
                                    ImdbID = movieId
                                });

            var result = webApi.GetMovie(movieId);

            Assert.AreEqual(movieId, result.Value.ImdbID);
        }
    }
}
