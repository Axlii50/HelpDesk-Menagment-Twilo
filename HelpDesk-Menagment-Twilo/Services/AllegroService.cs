using Allegro_Api;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Migrations;
using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly Dictionary<string, AllegroApi> _accounts;
       
        public AllegroService()
        {
            _accounts = new Dictionary<string, AllegroApi>();
            //_accounts = InitializeAllegroApis();
        }

        //private Dictionary<string, AllegroApi> InitializeAllegroApis()
        //{
        //    Dictionary<string, AllegroApi> dictionary = new Dictionary<string, AllegroApi>();

        //    var platformAccounts = _context.PlatformAccounts.Where(account => account.PlatformType == PlatformType.Allegro).ToList();

        //    foreach (var account in platformAccounts)
        //    {
        //        AllegroApi allegroApi;

        //        allegroApi = new AllegroApi(account.ClientID, account.ClientSecret, HandleRefreshToken);

        //        dictionary.Add(account.AccountName, allegroApi);
        //    }

        //    return dictionary;
        //}

        private void HandleRefreshToken()
        {

        }

        public async Task<string> GetVerificationUri(PlatformAccount platformAccount)
        {
            initializeAccount(platformAccount);

            var verificationUrlModel = await (_accounts[platformAccount.AccountName].Authenticate());

            // open link in browser
            Console.WriteLine("Link do autoryzacji: " + verificationUrlModel.verification_uri_complete);

            return verificationUrlModel.verification_uri_complete;
        }
        private void initializeAccount(PlatformAccount platformAccount)
        {
            var allegroApi = new AllegroApi(platformAccount.ClientID, platformAccount.ClientSecret, HandleRefreshToken);

            _accounts.Add(platformAccount.AccountName, allegroApi);
        }

        public async Task<bool> CheckAccessToken(string AccountName)
        {
            bool access = true;
            if (_accounts[AccountName].RefreshToken == string.Empty)
                access = await _accounts[AccountName].CheckForAccessToken(0);
            return access;
        }



        //Dictionary<Order, Account name>

        // Id paczki Id zamówienia Account name

        // new Package (uzupełniamy itd) <=> new PackageInfo (id => Package.PackageShippingID) (order id/account name
    }
}
