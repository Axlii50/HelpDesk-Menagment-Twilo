using Allegro_Api.Models.Order.checkoutform;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAllegroService _allegroService;

        public OrderService(IAllegroService allegroService)
        {
            _allegroService = allegroService;
        }

        public async Task<List<CheckOutForm>> GetAllOrders(string AccountName, Allegro_Api.OrderStatusType type)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var orders = await allegroapi.GetOrders(type);

            return orders;
        }

        public async Task<DetailedCheckOutForm> GetDetailedOrderById(string AccountName, string OrderId)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var order = await allegroapi.GetOrderDetails(OrderId);

            return order;
        }
    }
}
