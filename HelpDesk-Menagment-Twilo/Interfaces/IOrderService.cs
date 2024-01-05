namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IOrderService
    {
        Task<Allegro_Api.Models.Order.checkoutform.CheckOutForm> GetAllOrders(string AccountName, Allegro_Api.OrderStatusType type)
    }
}