using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageGeneratorService : IBackGroundService
    {
        private readonly IShippingService _shippingService;
        private readonly IOrderService _orderService;
        private readonly HelpDesk_Menagment_TwiloContext context;

        public PackageGeneratorService(IShippingService shippingService, IOrderService orderService, HelpDesk_Menagment_TwiloContext context)
        {
            _shippingService = shippingService;
            _orderService = orderService;
            this.context = context;
        }

        public async Task StartServiceTask()
        {
            //Download all orders new/Realization

            //Sort out all that are already in database

            //Generate number for rest
        }
    }
}
