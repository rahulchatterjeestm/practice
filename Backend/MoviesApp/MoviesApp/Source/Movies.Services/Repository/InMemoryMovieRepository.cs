using Movies.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Repository
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private List<Movie> movieList;
        private readonly IQueryable<Movie> queryAble;

        public InMemoryMovieRepository()
        {
            this.movieList = this.LoadData
            this.queryAble =  this.movieList.AsQueryable<Movie>();
        }

        public Type ElementType => this.queryAble?.ElementType ?? throw new ObjectDisposedException(null);

        public Expression Expression => this.queryAble?.Expression ?? throw new ObjectDisposedException(null);

        public IQueryProvider Provider => this.queryAble?.Provider ?? throw new ObjectDisposedException(null);

        public IEnumerator<Movie> GetEnumerator()
        {
            return this.movieList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.movieList.GetEnumerator();
        }

        private List<Movie> LoadData()
        {
            List<Movie> movies;
            //read form local json
            using (StreamReader streamReader = new StreamReader("./movies.json"))
            {
                var json = streamReader.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            return movies;
        }
    }
}
