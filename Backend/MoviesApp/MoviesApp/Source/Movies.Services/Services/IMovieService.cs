using Movies.Models.Models;
using System.Collections.Generic;

namespace Movies.Services.Services
{
    public interface IMovieService
    {
        Movie GetMovie(string id);

        List<Movie> GetMovies(string location = null, string language = null);
    }
}
