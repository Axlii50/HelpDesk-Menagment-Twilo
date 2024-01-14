using Allegro_Api.Shipment;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class DeliveryServicesService : IDeliveryServicesService
    {
        private readonly IAllegroService allegroService;

        public DeliveryServicesService(IAllegroService allegroService)
        {
            allegroService = allegroService;
            this.allegroService = allegroService;
        }

        public async Task<List<DeliveryServiceDto>> GetDeliveryServices(string accountName)
        {
            return (await allegroService.GetAllegroApi(accountName).GetDeliveryServices()).services.ToList();
        }
    }
}
