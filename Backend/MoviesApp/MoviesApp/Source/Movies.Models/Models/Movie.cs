﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.Models
{
    public class Movie
    {
        public string Id { get; set; }

        public string Language { get; set; }

        public string Location { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }

        public List<string> SoundEffects { get; set; }

        public List<string> Stills { get; set; }

        public string Title { get; set; }        

        public ListingType ListingType { get; set; }

        public string ImdbRating { get; set; }
    }
}