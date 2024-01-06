namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IShippingService
    {
        void CreateShipment(string AccountName, string OrderId);
    }
}
