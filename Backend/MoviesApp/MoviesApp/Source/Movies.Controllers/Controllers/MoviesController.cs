using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models.Models;
using Movies.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Movie>> GetAllMovies(string location = null,
                                               string language = null)
        {
            try
            {
                this.logger.LogInformation("Request received to get movies");
                return this.movieService.GetMovies(location, language);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
