using Ebiograf.Web.API.Models.Bookings;
using Ebiograf.Web.API.ModelsDto.BookingDto;
using Ebiograf.Web.API.Repository.PaymentRepo;
using Ebiograf.Web.API.Services.BookingsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.PaymentsService
{
    public class PaymentService:IPaymentService
    {
        public IPaymentRepository PaymentRepo;
        public PaymentService(IPaymentRepository _PaymentRepo)
        {
            PaymentRepo = _PaymentRepo;
        }





        public async Task<IEnumerable<Payment>> getPayments() => await PaymentRepo.getPayments();
        public async Task<Payment> GetPaymentByID(int PaymentID) => await PaymentRepo.GetPaymentByID(PaymentID);
        public async Task<Payment> CreatePayment(PaymentDto createPayment) => await PaymentRepo.CreatePayment(createPayment);
        public async Task<Payment> UpdatePayment(PaymentDto updatePayment, int PaymentID) => await PaymentRepo.UpdatePayment(updatePayment, PaymentID);
        public async Task<Payment> DeletePayment(int PaymentID) => await PaymentRepo.DeletePayment(PaymentID);
    }
}
