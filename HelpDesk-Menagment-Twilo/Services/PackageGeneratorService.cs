using Allegro_Api;
using Allegro_Api.Models.Order.checkoutform;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Package;
using Microsoft.Extensions.DependencyInjection;
using static NuGet.Packaging.PackagingConstants;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageGeneratorService : IBackGroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public PackageGeneratorService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartServiceTask()
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var allegroService = scope.ServiceProvider.GetRequiredService<IAllegroService>();
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                var shippingService = scope.ServiceProvider.GetRequiredService<IShippingService>();
                var context = scope.ServiceProvider.GetRequiredService<HelpDesk_Menagment_TwiloContext>();

                string[] authorizedAccounts = allegroService.GetAuthorizedAccounts();

                foreach (var accounts in authorizedAccounts)
                {
                    System.Diagnostics.Debug.WriteLine(accounts);
                }

                System.Diagnostics.Debug.WriteLine(" ");

                List<CheckOutForm> Orders = null;
                if (authorizedAccounts.Length > 0)
                {
                    Orders = await orderService.GetAllUnSavedOrders(authorizedAccounts[0]);

                    foreach (var order in Orders)
                    {
                        System.Diagnostics.Debug.WriteLine(order.id);
                    }
                }

                if (Orders != null)
                {
                    var order = Orders.FirstOrDefault();

                    shippingService.CreateShipment(authorizedAccounts[0], order.id);

                    var PackageInfo = new PackageInfo()
                    {
                        OrderId = new Guid(order.id),
                        
                    };
                }

                //Download all orders new/Realization

                //Sort out all that are already in database

                //Generate number for rest
            }
        }
    }
}
