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
                //Services
                var allegroService = scope.ServiceProvider.GetRequiredService<IAllegroService>();
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                var shippingService = scope.ServiceProvider.GetRequiredService<IShippingService>();
                var context = scope.ServiceProvider.GetRequiredService<HelpDesk_Menagment_TwiloContext>();
                var packageService = scope.ServiceProvider.GetRequiredService<IPackageService>();
                var deliveryServices = scope.ServiceProvider.GetRequiredService<IDeliveryServicesService>();
                var platformAccountService = scope.ServiceProvider.GetRequiredService<IPlatformAccountService>();

                //temp variables
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

                if (Orders != null && false)
                {
                    var platformAccount = platformAccountService.GetIdByName(authorizedAccounts[0]);
                    var aviableServices = await deliveryServices.GetDeliveryServices(authorizedAccounts[0]);
                    var order = Orders.FirstOrDefault();

                    var ServiceId = aviableServices.FirstOrDefault(ser => ser.id.deliveryMethodId == order.delivery.method.id).id.credentialsId;

                    var commandId = await shippingService.CreateShipment(authorizedAccounts[0], order.id, ServiceId);
                    System.Diagnostics.Debug.WriteLine($"{commandId}");

                    var PackageInfo = new PackageInfo()
                    {
                        OrderId = new Guid(order.id),
                        CreationCommandID = commandId,
                        PlatformAccountId = platformAccount
                    };

                    packageService.AddPackageInfo(PackageInfo);
                }
            }
        }
    }
}
