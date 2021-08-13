using Movies.Models.Models;
using Movies.Services.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public MovieDetail GetMovie(string id)
        {
            var query = this.movieRepository.AsQueryable();;
            query = query.Where(x => x.ImdbID == id);            

            return query.FirstOrDefault();
        }

        public List<Movie> GetMovies(string location = null, string language = null)
        {
            var query = this.movieRepository.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location == location);
            }

            if (!string.IsNullOrEmpty(language))
            {
                query = query.Where(x => x.Language == language);
            }

            return query.ToList<Movie>();
        }
    }
}
