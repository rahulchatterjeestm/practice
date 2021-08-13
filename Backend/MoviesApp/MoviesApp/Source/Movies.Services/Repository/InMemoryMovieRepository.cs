using Movies.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Services.Repository
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private readonly List<MovieDetail> movieList;
        private readonly IQueryable<MovieDetail> queryAble;

        public InMemoryMovieRepository()
        {
            this.movieList = this.LoadData();
            this.queryAble =  this.movieList.AsQueryable<MovieDetail>();
        }

        public Type ElementType => this.queryAble?.ElementType ?? throw new ObjectDisposedException(null);

        public Expression Expression => this.queryAble?.Expression ?? throw new ObjectDisposedException(null);

        public IQueryProvider Provider => this.queryAble?.Provider ?? throw new ObjectDisposedException(null);

        public IEnumerator<MovieDetail> GetEnumerator()
        {
            return this.movieList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.movieList.GetEnumerator();
        }

        private List<MovieDetail> LoadData()
        {
            List<MovieDetail> movies;
            var path = Environment.GetEnvironmentVariable("DB_PATH");
            //read from local json
            using (StreamReader streamReader = new StreamReader(path))
            {
                var json = streamReader.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<MovieDetail>>(json);
            }

            return movies;
        }
    }
}
