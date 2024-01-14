using Allegro_Api;
using Allegro_Api.Models.Order.checkoutform;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAllegroService _allegroService;
        private readonly IPackageService packageService;

        public OrderService(IAllegroService allegroService, IPackageService packageService)
        {
            _allegroService = allegroService;
            this.packageService = packageService;
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
                if (order.id == "53033100-b22b-11ee-aec8-b5646d1484ba")
                    System.Diagnostics.Debug.WriteLine("tt");
                if (!await packageService.CheckIfPackageInfoExist(new Guid(order.id)))
                    UnSavedOrders.Add(order);
            }

            return UnSavedOrders;
        }

        public async Task<DetailedCheckOutForm> GetDetailedOrderById(string AccountName, string OrderId)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var order = await allegroapi.GetOrderDetails(OrderId);

            return order;
        }
    }
}
