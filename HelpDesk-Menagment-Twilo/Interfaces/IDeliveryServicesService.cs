using Allegro_Api.Shipment;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IDeliveryServicesService
    {
        Task<List<DeliveryServiceDto>> GetDeliveryServices(string accountName);
    }
}