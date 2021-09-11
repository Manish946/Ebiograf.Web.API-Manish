using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.ModelsDto;
using Ebiograf.Web.API.ModelsDto.MovieDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<MovieWithGenreName>> GetMovies();
        public Task<MovieWithGenreName> GetMoviesByID(int MovieID);

        public Task<Movie> CreateMovie(CreateMovieModel CreateMovie);
        public Task<Movie> UpdateMovie(UpdateMovieModel CreateMovie);

        public Task<IEnumerable<MovieWithGenreName>> GetGenresMovie(int GenreID);
        public Task<Movie> DeleteMovie(int MovieID);
    }
}
