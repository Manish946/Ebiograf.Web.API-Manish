using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.CinemaServices
{
    public interface ICinemaSeatService
    {
        public Task<IEnumerable<CinemaSeat>> GetCinemaSeats();
        public Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID);
        public Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat);
        public Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID);
        public Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID);
    }
}
