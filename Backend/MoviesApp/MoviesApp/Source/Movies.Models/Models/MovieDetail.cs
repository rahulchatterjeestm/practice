using System.Collections.Generic;

namespace Movies.Models.Models
{
    public class MovieDetail: Movie
    {        

        public string Plot { get; set; }

        public List<string> SoundEffects { get; set; }

        public List<string> Stills { get; set; }

        public string ListingType { get; set; }

        public string ImdbRating { get; set; }
    }
}
