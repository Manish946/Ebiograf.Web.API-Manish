using Ebiograf.Web.API.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.BookingsService
{
    public interface ITicketService
    {
        public Task<IEnumerable<Ticket>> getTickets(int userID);
    }
}
