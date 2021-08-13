using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.Models
{
    public class Movie
    {
        public string ImdbID { get; set; }

        public string Language { get; set; }

        public string Location { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }
    }
}
