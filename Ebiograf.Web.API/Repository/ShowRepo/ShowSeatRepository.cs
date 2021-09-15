using AutoMapper;
using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.ModelsDto.ShowDto;
using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.ShowRepo
{
    public class ShowSeatRepository: IShowSeatRepository
    {
        private readonly EBiografDbContext context;
        private IMapper mapper;
        public ShowSeatRepository(EBiografDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        public async Task<ShowSeat> CreateShowSeat(ShowSeatDto createShowSeat)
        {
            var ShowSeat = mapper.Map<ShowSeat>(createShowSeat);
            await context.ShowSeats.AddAsync(ShowSeat);
            await context.SaveChangesAsync();
            return ShowSeat;
        }

        public async Task<ShowSeat> DeleteShowSeat(int ShowSeatID)
        {
            var deleteShowSeat = await context.ShowSeats.FindAsync(ShowSeatID);
            if (deleteShowSeat != null)
            {
                context.ShowSeats.Remove(deleteShowSeat);
                await context.SaveChangesAsync();
            }
            return deleteShowSeat;

        }

        public async Task<ShowSeat> GetShowSeatByID(int ShowSeatID)
        {
            return await context.ShowSeats.FindAsync(ShowSeatID);

        }

        public async Task<IEnumerable<ShowSeat>> getShowSeats()
        {
            return await context.ShowSeats.ToListAsync();
        }

        public async Task<ShowSeat> UpdateShowSeat(ShowSeatDto UpdateShowSeat, int ShowSeatID)
        {
            var updatedShowSeat = mapper.Map<ShowSeat>(UpdateShowSeat);
            var ShowSeat = await context.ShowSeats.FindAsync(ShowSeatID);
            if (ShowSeat == null)
            {
                throw new AppException("ShowSeat not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedShowSeat.Status.ToString()))
            {
               ShowSeat.Status = updatedShowSeat.Status;
            }
            if (!string.IsNullOrWhiteSpace(updatedShowSeat.Price.ToString()))
            {
               ShowSeat.Price = updatedShowSeat.Price;
            }
            if (!string.IsNullOrWhiteSpace(updatedShowSeat.ShowID.ToString()))
            {
               ShowSeat.ShowID = updatedShowSeat.ShowID;
            }
            if (!string.IsNullOrWhiteSpace(updatedShowSeat.CinemaSeatID.ToString()))
            {
               ShowSeat.CinemaSeatID = updatedShowSeat.CinemaSeatID;
            }
            if (!string.IsNullOrWhiteSpace(updatedShowSeat.BookingID.ToString()))
            {
               ShowSeat.BookingID = updatedShowSeat.BookingID;
            }
            
            context.ShowSeats.Update(ShowSeat);
            await context.SaveChangesAsync();

            return ShowSeat;

        }
    }
}
