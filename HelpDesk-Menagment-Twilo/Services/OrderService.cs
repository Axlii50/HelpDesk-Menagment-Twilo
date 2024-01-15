using Allegro_Api;
using Allegro_Api.Models.Order.checkoutform;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAllegroService _allegroService;
        private readonly IPackageService _packageService;

        public OrderService(IAllegroService allegroService, IPackageService packageService)
        {
            _allegroService = allegroService;
            this._packageService = packageService;
        }

        public async Task<List<CheckOutForm>> GetAllOrders(string AccountName, Allegro_Api.OrderStatusType type)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var orders = await allegroapi.GetOrders(type);

            return orders;
        }

        public async Task<List<CheckOutForm>> GetAllUnSavedOrders(string AccountName)
        {
            var UnSavedOrders = new List<CheckOutForm>();
            var Orders = await GetAllOrders(AccountName, OrderStatusType.NEW);
                Orders.AddRange( await GetAllOrders(AccountName, OrderStatusType.PROCESSING));

            foreach(var order in Orders)
            {
                if (!await _packageService.ExistPackageInfoByOrderId(new Guid(order.id)) && await PaymentCompleted(AccountName,order.id))
                    UnSavedOrders.Add(order);
            }

            return UnSavedOrders;
        }

        private async Task<bool> PaymentCompleted(string AccountName, string OrderId)
        {
            var Details = await GetDetailedOrderById(AccountName, OrderId);

            //return true if payment is completed
            if (Details.status == "BOUGHT" || Details.status == "READY_FOR_PROCESSING")
                return true;

            return false;
        }

        public async Task<DetailedCheckOutForm> GetDetailedOrderById(string AccountName, string OrderId)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var order = await allegroapi.GetOrderDetails(OrderId);

            return order;
        }
    }
}
