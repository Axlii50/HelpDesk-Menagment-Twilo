namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IShippingService
    {
        string CreateShipment(string AccountName, string OrderId);
    }
}
