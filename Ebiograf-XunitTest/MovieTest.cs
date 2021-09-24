using Ebiograf.Web.API.Controllers;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.ModelsDto;
using Ebiograf.Web.API.ModelsDto.MovieDto;
using Ebiograf.Web.API.Repository.MovieRepo;
using Ebiograf.Web.API.Services.MovieService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ebiograf_XunitTest
{
    public class MovieTest
    {
        Mock<IMovieService> MovieMock = new Mock<IMovieService>();
        MovieController movieController;
        public MovieTest()
        {
            movieController = new MovieController(MovieMock.Object);
        }

        [Fact]
        public async void getAllMovies_HttpRsponse200_whenDataExists()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            List<MovieWithGenreName> movieList = new List<MovieWithGenreName>();
            movieList.Add(new MovieWithGenreName());
            movieList.Add(new MovieWithGenreName());
            movieList.Add(new MovieWithGenreName());
            MovieMock.Setup(context => context.GetMovies()).ReturnsAsync(movieList);

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.GetAllMovies();

            //Assert - Check if data is going through correctly.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAllMovies_HttpRsponse200_whenDataNoExists()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            List<MovieWithGenreName> movieList = new List<MovieWithGenreName>();
            MovieMock.Setup(context => context.GetMovies()).ReturnsAsync(movieList);

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.GetAllMovies();

            //Assert - Check if data is going through correctly.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void createMovie_shouldReturn201_WhenCreated()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            CreateMovieModel Movie = new CreateMovieModel()
            {
                MovieID = 1,
                Censorship = "over 10 years old.",
                Country = "USA",
                Description = "movie",
                Title = "Spider Mamn",
                Duration = 90,
                Genres = null,
                ImgLink = "none",
                Language = "English",
                ReleaseDate = new DateTime(),
                TrailerLink = "none"


            };
            MovieMock.Setup(context => context.CreateMovie(Movie));

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.CreateMovie(Movie);

            //Assert - Check if data is going through correctly.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void createMovie_shouldReturn400_WhenNoCreatedData()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            CreateMovieModel Movie = new CreateMovieModel()
            {
                MovieID = 1,
                Censorship = "over 10 years old.",
                Country = "USA",
                Description = "movie",
                Title = "Spider Mamn",
                Duration = 90,
                Genres = null,
                ImgLink = "none",
                Language = "English",
                ReleaseDate = new DateTime(),
                TrailerLink = "none"


            };
            MovieMock.Setup(context => context.CreateMovie(Movie));

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.CreateMovie(null);

            //Assert - Check if data is going through correctly.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void deleteMovie_HttpRsponse200_whenDataDoestExists()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            var movieID = 1;
            MovieMock.Setup(context => context.DeleteMovie(movieID));

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.DeleteMovie(movieID);

            //Assert - Check if data is going through correctly.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void deleteMovie_HttpRsponse200_whenDataExists()
        {
            //Arrange - Opsætning => variable init
            // objectController and mock data
            var movieID = 1;
            MovieMock.Setup(context => context.DeleteMovie(movieID));

            //ACT - Handling => prøve Movie Data
            IActionResult result = await movieController.DeleteMovie(movieID);

            //Assert - Check if data is going through correctly.
            MovieMock.Verify(v => v.DeleteMovie(movieID), Times.Once());
        }

    }
}
