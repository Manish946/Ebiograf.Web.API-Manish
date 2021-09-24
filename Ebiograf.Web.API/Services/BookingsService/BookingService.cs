using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using Ebiograf.Web.API.Repository.BookingRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.BookingsService
{
    public class BookingService:IBookingService
    {
        public IBookingRepository bookingRepo;
        public BookingService(IBookingRepository _bookingRepo)
        {
            bookingRepo = _bookingRepo;
        }



        public async Task<IEnumerable<Booking>> getBookings() => await bookingRepo.getBookings();
        public async Task<Booking> GetBookingByID(int BookingID) => await bookingRepo.GetBookingByID(BookingID);
        public async Task<Booking> CreateBookingWithData(Booking booking) => await bookingRepo.CreateBookingWithData(booking);
        public async Task<IEnumerable<Booking>> GetBookingByuserID(int userID) => await bookingRepo.GetBookingByuserID(userID);

        public async Task<Booking> CreateBooking(BookingDto createBooking) => await bookingRepo.CreateBooking(createBooking);
        public async Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID) => await bookingRepo.UpdateBooking(updateBooking, BookingID);
        public async Task<Booking> DeleteBooking(int BookingID) => await bookingRepo.DeleteBooking(BookingID);

    }
}
