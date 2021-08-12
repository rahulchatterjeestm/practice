using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models.Models;
using Movies.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly ILogger<MoviesController> logger;

        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            this.logger = logger;
            this.movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAllMovies(string location = null,
                                               string language = null)
        {
            this.logger.LogInformation("Request received to get all movies");
            return this.movieService.GetMovies(location, language);
        }

        [HttpGet("{movieId}")]
        public ActionResult<Movie> GetMovie([Required] string movieId)
        {
            var resultMovie = this.movieService.GetMovie(movieId);
            if (resultMovie == null)
            {
                return NotFound();
            }

            return Ok(resultMovie);
        }
    }
}
