using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.BookingsService
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> CreateBookingWithData(Booking booking);

        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);

    }
}
