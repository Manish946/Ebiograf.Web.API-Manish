using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.CinemaRepo
{
    public interface ICinemaRepository
    {
        public Task<IEnumerable<Cinema>> GetCinemas();
        public Task<Cinema> GetCinemaByID(int CinemaID);
        public Task<Cinema> CreateCinema(CinemaModelDto CreateCinema);
        public Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID);
        public Task<Cinema> DeleteCinema(int CinemaID);
    }
}
