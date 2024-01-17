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

                //All authorized accounts 
                string[] authorizedAccounts = allegroService.GetAuthorizedAccounts();

                foreach (var authorizedAccount in authorizedAccounts)
                {
                    //prepare all neccessary data

                    //All unsaved orders
                    var Orders = await orderService.GetAllUnSavedOrders(authorizedAccount);
                    //get platfrom account id that is linked to such authorized account 
                    var platformAccount = platformAccountService.GetIdByName(authorizedAccount);
                    //Get all aviable delivery services for specific account
                    var aviableServices = await deliveryServices.GetDeliveryServices(authorizedAccount);

                    //iterate throug each order and generate package for it
                    foreach (var order in Orders)
                    {
                        //find services for specific order
                        var ServiceId = aviableServices.FirstOrDefault(ser => ser.id.deliveryMethodId == order.delivery.method.id).id.credentialsId;

                        //create shipping package and return command id for later usage
                        var commandId = await shippingService.CreateShipment(authorizedAccounts[0], order.id, ServiceId);

                        //create object of package info 
                        var PackageInfo = new PackageInfo()
                        {
                            OrderId = new Guid(order.id),
                            CreationCommandID = commandId,
                            PlatformAccountId = platformAccount
                        };

                        //add package info to database
                        packageService.AddPackageInfo(PackageInfo);
                    }
                }
            }
        }
    }
}
