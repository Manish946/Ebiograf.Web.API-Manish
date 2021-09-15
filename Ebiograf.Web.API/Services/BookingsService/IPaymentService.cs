using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.BookingsService
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> getPayments();
        public Task<Payment> GetPaymentByID(int PaymentID);
        public Task<Payment> CreatePayment(PaymentDto createPayment);
        public Task<Payment> UpdatePayment(PaymentDto updatePayment, int PaymentID);
        public Task<Payment> DeletePayment(int PaymentID);
    }
}
