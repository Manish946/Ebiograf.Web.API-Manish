using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.ModelsDto.ShowDto;
using Ebiograf.Web.API.Repository.ShowRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.ShowsService
{
    public class ShowSeatService:IShowSeatService
    {
        public IShowSeatRepository ShowSeatRepo;
        public ShowSeatService(IShowSeatRepository _ShowSeatRepo)
        {
            ShowSeatRepo = _ShowSeatRepo;
        }

        public async Task<IEnumerable<ShowSeat>> getShowSeats() => await ShowSeatRepo.getShowSeats();
        public async Task<ShowSeat> GetShowSeatByID(int ShowSeatID) => await ShowSeatRepo.GetShowSeatByID(ShowSeatID);
        public async Task<ShowSeat> CreateShowSeat(ShowSeatDto createShowSeat) => await ShowSeatRepo.CreateShowSeat(createShowSeat);
        public async Task<ShowSeat> UpdateShowSeat(ShowSeatDto updateShowSeat, int ShowSeatID) => await ShowSeatRepo.UpdateShowSeat(updateShowSeat, ShowSeatID);
        public async Task<ShowSeat> DeleteShowSeat(int ShowSeatID) => await ShowSeatRepo.DeleteShowSeat(ShowSeatID);
    }
}
