using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.Repository.MovieRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ebiograf.Web.API.ModelsDto;
using Ebiograf.Web.API.ModelsDto.MovieDto;

namespace Ebiograf.Web.API.Services.MovieService
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository movieRepo;
        private  IMapper mapper;
        public MovieService(IMovieRepository _movieRepo, IMapper _mapper)
        {
            movieRepo = _movieRepo;
            mapper = _mapper;
        }

        public async Task<IEnumerable<MovieWithGenreName>> GetMovies()
        {
            var Movie =  await movieRepo.GetMovies();
            
            return Movie;
        }

        public async Task<MovieWithGenreName> GetMoviesByID(int MovieID) => await movieRepo.GetMoviesByID(MovieID);
        public async Task<Movie> CreateMovie(CreateMovieModel Movies) => await movieRepo.CreateMovie(Movies);
        public async Task<Movie> UpdateMovie(UpdateMovieModel updateMovie) => await movieRepo.UpdateMovie(updateMovie);
        public async Task<IEnumerable<MovieWithGenreName>> GetGenresMovie(int GenreID) => await movieRepo.GetGenresMovie(GenreID);
        public async Task<Movie> DeleteMovie(int MovieID) => await movieRepo.DeleteMovie(MovieID);

    }
}
