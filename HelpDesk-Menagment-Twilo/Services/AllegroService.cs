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
        /// <summary>
        /// Key to jest nazwa konta
        /// </summary>
        private readonly Dictionary<string, AllegroApi> _accounts;
        private readonly ILogger<AllegroService> _logger;

        public AllegroService(ILogger<AllegroService> logger)
        {
            _accounts = new Dictionary<string, AllegroApi>();
            _logger = logger;
        }

        private void HandleRefreshToken()
        {

        }

        public async Task<string> GetVerificationUri(PlatformAccount platformAccount)
        {
            // Initialize the account for Allegro API authentication
            initializeAccount(platformAccount);
            // Authenticate the account and retrieve the verification URL
            var verificationUrlModel = await (_accounts[platformAccount.AccountName].Authenticate());

            // Return the complete verification URL
            return verificationUrlModel.verification_uri_complete;
        }

        // Initializes an Allegro account for authentication
        private void initializeAccount(PlatformAccount platformAccount)
        {
            // Create a new instance of AllegroApi and add it to the accounts dictionary
            var allegroApi = new AllegroApi(platformAccount.ClientID, platformAccount.ClientSecret, HandleRefreshToken);

            //przy ponownej autoryzacji usunie stary obiekt który nie został zautoryzowany by móc poprawnie przejsc autoryzacjie bez resetowania poola
            if(_accounts.ContainsKey(platformAccount.AccountName))
            {
                _accounts.Add(platformAccount.AccountName, allegroApi);
            }
            else
            {
                _accounts.Remove(platformAccount.AccountName);
                _accounts.Add(platformAccount.AccountName, allegroApi);
            }
        }

        // Checks if the access token for the specified account is valid
        public async Task<bool> CheckAccessToken(string AccountName)
        {
            bool access = true;

            // If the refresh token is empty, attempt to get a new access token
            if (_accounts[AccountName].RefreshToken == string.Empty)
                access = await _accounts[AccountName].CheckForAccessToken(0);

            return access;
        }

        public AllegroApi GetAllegroApi (string AccountName)
        {
            if (!_accounts.ContainsKey(AccountName)) return null;

            return _accounts[AccountName];
        }


        public string[] GetAuthorizedAccounts()
        {
            return _accounts.Where(acc => acc.Value.RefreshToken != string.Empty).Select(acc => acc.Key).ToArray();
        }

        public bool IsAuthorized(string AccountName)
        {
            if (_accounts.ContainsKey(AccountName))
                return _accounts[AccountName].RefreshToken != string.Empty;
            else return false;
        }
    }
}
