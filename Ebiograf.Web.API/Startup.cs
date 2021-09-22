using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Repository.UserRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EBiograf.Web.Api.Helper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EBiograf.Web.Api.Services;
using Microsoft.IdentityModel.Tokens;
using Ebiograf.Web.API.Services.MovieService;
using Ebiograf.Web.API.Repository.MovieRepo;
using Newtonsoft.Json;
using Ebiograf.Web.API.Repository.GenreRepo;
using Ebiograf.Web.API.Services.GenreService;
using Ebiograf.Web.API.Repository.CinemaAddressRepo;
using Ebiograf.Web.API.Services.CinemaAddressService;
using Ebiograf.Web.API.Repository.CinemaRepo;
using Ebiograf.Web.API.Services.CinemaServices;
using Ebiograf.Web.API.Repository.ShowRepo;
using Ebiograf.Web.API.Services.ShowsService;
using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.Repository.BookingRepo;
using Ebiograf.Web.API.Services.BookingsService;
using Ebiograf.Web.API.Repository.SnackRepo;
using Ebiograf.Web.API.Services.SnackService;
using Ebiograf.Web.API.Repository.PaymentRepo;
using Ebiograf.Web.API.Services.PaymentsService;
using Ebiograf.Web.API.Repository.CinemaSeatRepo;
using Ebiograf.Web.API.Services.CinemaSeatServices;

namespace Ebiograf.Web.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;
        public Startup(IConfiguration configuration, IWebHostEnvironment _env)
        {
            Configuration = configuration;
            env = _env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsProduction())
            {
                services.AddDbContext<EBiografDbContext>();
            }

            services.AddCors();
            services.AddControllers();
            // Adding DbContext class to services. connection string to mssql database  Then we can add migration.
            services.AddDbContext<EBiografDbContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("Connection"));
              }, ServiceLifetime.Transient);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
            services.AddAuthentication(x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var userId = int.Parse(context.Principal.Identity.Name);
                            var user = userService.GetById(userId);
                            if (user == null)
                            {
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
                );


            // Adding User Scope so that we can call from Endpoint.
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ImovieRepository, MovieService>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<ICinemaAddressRepository, CinemaAddressRepository>();
            services.AddScoped<ICinemaAddressService, CinemaAddressService>();

            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<ICinemaService, CinemaService>();

            services.AddScoped<ICinemaHallRepository, CinemaHallRepository>();
            services.AddScoped<ICinemaHallService, CinemaHallService>();

            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IShowService, ShowService>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<IShowSeatRepository, ShowSeatRepository>();
            services.AddScoped<IShowSeatService, ShowSeatService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IOrderSnackRepository, OrderSnackRepository>();
            services.AddScoped<IOrderSnackService, OrderSnackService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<ICinemaSeatRepository, CinemaSeatRepository>();
            services.AddScoped<ICinemaSeatService, CinemaSeatService>();


            services.AddControllers()
               .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EBiografDbContext DatabaseContext)
        {
            DatabaseContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ebiograf.Web.API v1"));
            }
            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
