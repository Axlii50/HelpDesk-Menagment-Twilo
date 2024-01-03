using Allegro_Api;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly Dictionary<Guid, AllegroApi> _accounts;
        private readonly HelpDesk_Menagment_TwiloContext _context;

        public AllegroService(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
            _accounts = InitializeAllegroApis();
        }

        private Dictionary<Guid, AllegroApi> InitializeAllegroApis()
        {
            Dictionary<Guid, AllegroApi> dictionary = new Dictionary<Guid, AllegroApi>();

            var platformAccounts = _context.PlatformAccounts.Where(account => account.PlatformType == PlatformType.Allegro).ToList();

            foreach (var account in platformAccounts)
            {
                AllegroApi allegroApi;

                if (!string.IsNullOrEmpty(/*refresh token*/))
                {
                    allegroApi = new AllegroApi(account.ClientID, account.ClientSecret, /*refresh token*/, HandleRefreshToken);
                }
                else
                {
                    allegroApi = new AllegroApi(account.ClientID, account.ClientSecret, HandleRefreshToken);
                }

                dictionary.Add(Guid.NewGuid(), allegroApi);
            }

            return dictionary;
        }

        private void HandleRefreshToken()
        {

        }

        public async Task<bool> AuthorizeAllegroAccount(Guid accountId, AllegroPermissionState permissions)
        {
            var allegroApi = _accounts.FirstOrDefault(api => api.Key == accountId).Value;

            if (allegroApi == null)
                return false;

            var verificationUrlModel = await allegroApi.Authenticate();

            // open link in browser
            Console.WriteLine("Link do autoryzacji: " + verificationUrlModel.verification_uri_complete);

            bool access = await allegroApi.CheckForAccessToken(permissions);

            if (!access)
            {
                return false;
            }

            allegroApi.RefreshAccesToken();

            return true;
        }

        //Dictionary<Order, Account name>

        // Id paczki Id zamówienia Account name

        // new Package (uzupełniamy itd) <=> new PackageInfo (id => Package.PackageShippingID) (order id/account name
    }
}
