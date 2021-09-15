using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);
    }
}
