using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.CinemaRepo
{
    public interface ICinemaHallRepository
    {
        public Task<IEnumerable<CinemaHall>> GetCinemaHalls();
        public Task<CinemaHall> GetCinemaHallByID(int CinemaHallID);
        public Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall);
        public Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID);
        public Task<CinemaHall> DeleteCinemaHall(int CinemaHallID);
    }
}
