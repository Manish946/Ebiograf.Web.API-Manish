﻿using Ebiograf.Web.API.Models.Movie;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.MovieDto
{
    public class UpdateMovieModel
    {

        public int MovieID { get; set; }
        public string Title { get; set; }

        public string ImgLink { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Censorship { get; set; }

        public string Country { get; set; }


        // Foreign Key for Genre
        public int[] GenresID { get; set; }
        public string TrailerLink { get; set; }
    }
}
