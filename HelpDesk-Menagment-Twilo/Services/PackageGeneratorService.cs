using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageGeneratorService : IBackGroundService
    {
        private readonly IShippingService _shippingService;
        private readonly IOrderService _rderService;

        public PackageGeneratorService(IShippingService shippingService, IOrderService orderService)
        {
            _shippingService = shippingService;
            _orderService = orderService;
        } 

        public async Task StartServiceTask()
        {
            
        }
    }
}
