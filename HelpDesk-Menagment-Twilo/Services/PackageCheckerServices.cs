using Allegro_Api;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageCheckerService : IBackGroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public PackageCheckerService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartServiceTask()
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                //Services
                var allegroService = scope.ServiceProvider.GetRequiredService<IAllegroService>();
                var context = scope.ServiceProvider.GetRequiredService<HelpDesk_Menagment_TwiloContext>();

                var packages = context.PackageInfo.Include(pac => pac.PlatformAccount).Where(pac => pac.CreationCommandID != string.Empty);

                foreach (var package in packages)
                {
                    var account = allegroService.GetAllegroApi(package.PlatformAccount.AccountName);

                    if (account == null) continue;

                    var responseStatus = await account?.CheckPackageCreationStatus(package.CreationCommandID);

                    if (responseStatus.Status == "ERROR")
                    {
                        package.CreationCommandType = Models.DataBase.Package.CreationCommandType.Error;
                        context.Update(package);
                    }
                    else if (responseStatus.Status == "SUCCESS")
                    {
                        package.PackageShippingId = responseStatus.ShipmentId;
                        package.PackageWayBill = (await account.GetParcelNumbers(package.OrderId.ToString())).shipments[0].waybill;
                        package.CreationCommandType = Models.DataBase.Package.CreationCommandType.Success;
                        package.CreationCommandID = string.Empty;
                        context.Update(package);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
