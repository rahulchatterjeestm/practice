using Movies.Models.Models;
using System.Linq;

namespace Movies.Services.Repository
{
    public interface IMovieRepository: IQueryable<Movie>
    {
    }
}
