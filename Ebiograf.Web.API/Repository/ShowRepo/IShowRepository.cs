using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.ModelsDto.ShowDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.ShowRepo
{
    public interface IShowRepository
    {
        public Task<IEnumerable<Show>> GetShows();
        public Task<Show> GetShowByID(int CinemaID);
        public Task<Show> CreateShow(ShowDetailsDto CreateShow);
        public Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID);
        public Task<Show> DeleteShow(int ShowID);
    }
}
