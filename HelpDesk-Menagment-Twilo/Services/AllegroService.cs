using Allegro_Api;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Migrations;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly Dictionary<string, AllegroApi> _accounts;
        private readonly HelpDesk_Menagment_TwiloContext _context;

        public AllegroService(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
            _accounts = InitializeAllegroApis();
        }

        private Dictionary<string, AllegroApi> InitializeAllegroApis()
        {
            Dictionary<string, AllegroApi> dictionary = new Dictionary<string, AllegroApi>();

            var platformAccounts = _context.PlatformAccounts.Where(account => account.PlatformType == PlatformType.Allegro).ToList();

            foreach (var account in platformAccounts)
            {
                AllegroApi allegroApi;

                allegroApi = new AllegroApi(account.ClientID, account.ClientSecret, HandleRefreshToken);

                dictionary.Add(account.AccountName, allegroApi);
            }

            return dictionary;
        }

        private void HandleRefreshToken()
        {

        }

        public async Task<bool> GetVerificationUri(string accountName)
        {
            var allegroApi = _accounts.FirstOrDefault(api => api.Key == accountName).Value;

            if (allegroApi == null)
                return false;

            var verificationUrlModel = await allegroApi.Authenticate();

            // open link in browser
            Console.WriteLine("Link do autoryzacji: " + verificationUrlModel.verification_uri_complete);

            bool access = await CheckAccessToken(allegroApi);

            if (!access)
            {
                return false;
            }

            allegroApi.RefreshAccesToken();

            return true;
        }

        public async Task<bool> CheckAccessToken(AllegroApi allegroApi)
        {
            Allegro_Api.AllegroPermissionState Permissions =
                        AllegroPermissionState.allegro_api_sale_offers_read |
                        AllegroPermissionState.allegro_api_sale_offers_write |
                        AllegroPermissionState.allegro_api_sale_settings_read |
                        AllegroPermissionState.allegro_api_sale_settings_write;

            bool access = await allegroApi.CheckForAccessToken(Permissions);

            return access;
        }

        //Dictionary<Order, Account name>

        // Id paczki Id zamówienia Account name

        // new Package (uzupełniamy itd) <=> new PackageInfo (id => Package.PackageShippingID) (order id/account name
    }
}
