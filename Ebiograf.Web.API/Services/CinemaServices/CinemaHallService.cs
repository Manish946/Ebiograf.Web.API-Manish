using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaDto;
using Ebiograf.Web.API.Repository.CinemaRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.CinemaServices
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly ICinemaHallRepository cinemaHallRepo;
        public CinemaHallService(ICinemaHallRepository _cinemaHallRepo)
        {
            cinemaHallRepo = _cinemaHallRepo;
        }

        public async Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall) => await cinemaHallRepo.CreateCinemaHall(CreateCinemaHall);

        public async Task<CinemaHall> DeleteCinemaHall(int CinemaHallID) => await cinemaHallRepo.DeleteCinemaHall(CinemaHallID);

        public async Task<CinemaHall> GetCinemaHallByID(int CinemaHallID) => await cinemaHallRepo.GetCinemaHallByID(CinemaHallID);

        public async Task<IEnumerable<CinemaHall>> GetCinemaHalls() => await cinemaHallRepo.GetCinemaHalls();


        public async Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID) => await cinemaHallRepo.UpdateCinemaHall(UpdateCinemaHall, CinemaHallID);

    }
}
