using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.Repository.BookingRepo;
using Ebiograf.Web.API.Repository.MovieRepo;
using Ebiograf.Web.API.Repository.PaymentRepo;
using Ebiograf.Web.API.Services.MovieService;
using EBiograf.Web.Api.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.BookingsService
{
    public class TicketService : ITicketService
    {
        public IBookingRepository bookingRepo;
        public IMovieRepository movieRepo;
        public IUserRepository userRepo;
        public IPaymentRepository paymentRepo;
        public TicketService(
            IBookingRepository _bookingRepo,
            IMovieRepository movieRepo,
            IUserRepository userRepo,
            IPaymentRepository paymentRepo
            ) // Dependency Injection. 
        {

        }
        public Task<IEnumerable<Ticket>> getTickets(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
