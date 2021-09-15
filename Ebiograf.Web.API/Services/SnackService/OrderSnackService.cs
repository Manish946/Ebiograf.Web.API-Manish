using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using Ebiograf.Web.API.Repository.SnackRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.SnackService
{
    public class OrderSnackService:IOrderSnackService
    {
        public IOrderSnackRepository OrderSnackRepo;
        public OrderSnackService(IOrderSnackRepository _OrderSnackRepo)
        {
            OrderSnackRepo = _OrderSnackRepo;
        }





        public async Task<IEnumerable<OrderSnack>> getOrderSnacks() => await OrderSnackRepo.getOrderSnacks();
        public async Task<OrderSnack> GetOrderSnackByID(int OrderSnackID) => await OrderSnackRepo.GetOrderSnackByID(OrderSnackID);
        public async Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack) => await OrderSnackRepo.CreateOrderSnack(createOrderSnack);
        public async Task<OrderSnack> UpdateOrderSnack(OrderSnackDto updateOrderSnack, int OrderSnackID) => await OrderSnackRepo.UpdateOrderSnack(updateOrderSnack, OrderSnackID);
        public async Task<OrderSnack> DeleteOrderSnack(int OrderSnackID) => await OrderSnackRepo.DeleteOrderSnack(OrderSnackID);
    }
}
