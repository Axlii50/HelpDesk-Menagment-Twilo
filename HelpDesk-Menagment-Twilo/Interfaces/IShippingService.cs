namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IShippingService
    {
        Task<string> CreateShipment(string AccountName, string OrderId);
    }
}
