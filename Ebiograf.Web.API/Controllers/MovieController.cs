using Ebiograf.Web.API.Services.MovieService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ebiograf.Web.API.ModelsDto;
using EBiograf.Web.Api.Helper;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.ModelsDto.MovieDto;
using Microsoft.AspNetCore.Authorization;

namespace Ebiograf.Web.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public ImovieRepository context { get; set; }

        public MovieController(ImovieRepository _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await context.GetMovies();
                
                // var MovieWithGenre = mapper.Map<ICollection<MovieWithGenreName>>(movies);

                return Ok(movies);
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{MovieID}")]
        public async Task<IActionResult> GetMovieByID(int MovieID)
        {
            try
            {
                var MovieByID = await context.GetMoviesByID(MovieID).ConfigureAwait(false);

                if (MovieByID == null)
                {
                    return BadRequest(new { message = "MovieID is null." });
                }

                return Ok(MovieByID);
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("GenreMovie/{GenreID}")]
        public async Task<IActionResult> GetGenresMovie(int GenreID)
        {
            try
            {
                var GenresMovie = await context.GetGenresMovie(GenreID);
                return Ok(GenresMovie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieModel Createmodel)
        {

            try
            {
                // Create user
                var movie = await context.CreateMovie(Createmodel);

                return Ok(movie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieModel UpdateModel)
        {
            try
            {
                var movie = await context.UpdateMovie(UpdateModel);
                return Ok(movie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteMovie/{MovieID}")]
        public async Task<IActionResult> DeleteMovie(int MovieID)
        {
            try
            {
                var movieToDelete = await context.DeleteMovie(MovieID);
                return Ok();
            }
            catch (Exception ex)
            {

                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
       
    }
}
