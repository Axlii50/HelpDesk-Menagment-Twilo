using Allegro_Api.Shipment;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class DeliveryServicesService : IDeliveryServicesService
    {
        private readonly IAllegroService _allegroService;

        public DeliveryServicesService(IAllegroService allegroService)
        {
            allegroService = allegroService;
            this._allegroService = allegroService;
        }

        public async Task<List<DeliveryServiceDto>> GetDeliveryServices(string accountName)
        {
            return (await _allegroService.GetAllegroApi(accountName).GetDeliveryServices()).services?.ToList();
        }
    }
}
