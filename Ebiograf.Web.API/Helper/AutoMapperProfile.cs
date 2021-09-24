using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using Ebiograf.Web.API.ModelsDto.CinemaAddressDto;
using Ebiograf.Web.API.ModelsDto.CinemaDto;
using Ebiograf.Web.API.ModelsDto.GenreDto;
using Ebiograf.Web.API.ModelsDto.MovieDto;
using Ebiograf.Web.API.ModelsDto.ShowDto;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using EBiograf.Web.Api.Models;

namespace EBiograf.Web.Api.Helper
{
    //The automapper profile contains the mapping configuration used by the application, AutoMapper is a package available on Nuget that enables automatic mapping of one type of classes to another.
    //In this example we're using it to map between User entities and a few different model types - UserModel, RegisterModel and UpdateModel.
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<RegisterModelUser, User>().ReverseMap();
            CreateMap<UpdateModel, User>().ReverseMap();
            //CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            // This will Map the remaning property and in this case Gernes Names will be stored in an array from Collection Genre.
            CreateMap<Movie, MovieWithGenreName>()
                .ForMember(movie => movie.Genres,
                igenre => igenre.MapFrom(genre => genre.Genres
                .Select(g => g.GenreName).ToArray())).ReverseMap();
           //CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            //    .ForMember(Movie => Movie.Genres, Igenre => Igenre.MapFrom(genre => new Genre() { }));
            CreateMap<CreateMovieModel, Movie>().ReverseMap();
            CreateMap<UpdateMovieModel, Movie>().ReverseMap();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<CreateGenre, Genre>().ReverseMap();
            CreateMap<CinemaAddress, AddressDto>().ReverseMap();
            CreateMap<Cinema, CinemaModelDto>().ReverseMap();
            CreateMap<CinemaSeat, CinemaSeatModelDto>().ReverseMap();
            CreateMap<CinemaHall,CinemaHallDto>().ReverseMap();
            CreateMap<Show, ShowDetailsDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<ShowSeat, ShowSeatDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OrderSnack, OrderSnackDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
