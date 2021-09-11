using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Models.Movie
{
    public class GenreMovie
    {
        public int GenresGenreID { get; set; }
        public int MoviesMovieID { get; set; }

        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}
