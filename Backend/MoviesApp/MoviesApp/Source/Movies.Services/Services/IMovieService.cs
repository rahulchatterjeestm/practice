using Movies.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public interface IMovieService
    {
        Movie GetMovie(string id);

        List<Movie> GetMovies(string location = null, string language = null);
    }
}
