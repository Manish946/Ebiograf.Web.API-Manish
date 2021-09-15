using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.SnackService
{
    public interface IOrderSnackService
    {
        public Task<IEnumerable<OrderSnack>> getOrderSnacks();
        public Task<OrderSnack> GetOrderSnackByID(int OrderSnackID);
        public Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack);
        public Task<OrderSnack> UpdateOrderSnack(OrderSnackDto updateOrderSnack, int OrderSnackID);
        public Task<OrderSnack> DeleteOrderSnack(int OrderSnackID);
    }
}
