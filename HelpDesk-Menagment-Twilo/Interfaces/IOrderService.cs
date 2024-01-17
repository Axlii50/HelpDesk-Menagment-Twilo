using Allegro_Api.Models.Order.checkoutform;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IOrderService
    {
        Task<List<Allegro_Api.Models.Order.checkoutform.CheckOutForm>> GetAllOrders(string AccountName, Allegro_Api.OrderStatusType type);

        Task<DetailedCheckOutForm> GetDetailedOrderById(string AccountName, string OrderId);

        Task<List<CheckOutForm>> GetAllUnSavedOrders(string AccountName);

    }
}