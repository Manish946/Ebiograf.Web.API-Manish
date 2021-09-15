using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.Models.Snacks;
using EBiograf.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Environment
{
    public class EBiografDbContext : DbContext
    {
        //Ebiograf Db Constructor. Base options Connection string will be set in Statup Class.
        public EBiografDbContext(DbContextOptions<EBiografDbContext> options) : base(options) { }

        //  Migrating Database Table Users into SqlDatabase.
        // USER DATABASES
        public DbSet<User> Users { get; set; }
        // MOVIE DATABASES
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> GenreMovie {get;set;}
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowSeat> ShowSeats { get; set; }
        public DbSet<OrderSnack> OrderSnacks { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaAddress> CinemaAddresses { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<CinemaSeat> CinemaSeats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        // Relationship Configuring via the Fluent API for EF Core to be able to map it successfully.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie Model Building
            modelBuilder.Entity<Movie>().HasMany(x => x.Genres)
                .WithMany(x => x.Movies)
                .UsingEntity<GenreMovie>(
                    x => x.HasOne(x => x.Genre)
                    .WithMany().HasForeignKey(x => x.GenresGenreID),
                    x => x.HasOne(x => x.Movie)
                   .WithMany().HasForeignKey(x => x.MoviesMovieID));

        }

    }
}
