using Movies.Models.Models;
using Movies.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public class MovieService: IMovieService
    {
        private readonly IQueryable<Movie> queryAble;

        public MovieService(IMovieRepository movieRepository)
        {
            this.queryAble = movieRepository.AsQueryable();
        }

        public Movie GetMovies(string id = null)
        {
            var query = this.queryAble;
            if(!string.IsNullOrEmpty(id))
            {
                query = query.Where(x => x.ImdbID == id);
            }

            return query.Single();
        }

        public List<Movie> SearchMovies(string location = null, string language = null)
        {
            var query = this.queryAble;

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location == location);
            }

            if (!string.IsNullOrEmpty(language))
            {
                query = query.Where(x => x.Language == language);
            }

            return query.ToList();
        }
    }
}
