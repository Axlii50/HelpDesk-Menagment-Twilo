using Allegro_Api;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Migrations;
using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class AllegroService : IAllegroService
    {
        /// <summary>
        /// Key to jest nazwa konta
        /// </summary>
        private readonly Dictionary<string, AllegroApi> _accounts;
        private readonly ILogger<AllegroService> _logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public AllegroService(ILogger<AllegroService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _accounts = new Dictionary<string, AllegroApi>();
            _logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        private void HandleRefreshToken()
        {
            _logger.LogInformation(_accounts.Count().ToString());

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HelpDesk_Menagment_TwiloContext>();

                foreach (var account in _accounts)
                {
                    AssignRefreshToken(account.Key);
                    _logger.LogInformation("Aktualizuje token dla konta: " + account.Key);
                    System.Diagnostics.Debug.WriteLine($"Konto {account.Key} zostało zaktualizowane");
                }
            }
        }

        public async Task<string> GetVerificationUri(PlatformAccount platformAccount)
        {
            // Initialize the account for Allegro API authentication
            initializeAccount(platformAccount);
            // Authenticate the account and retrieve the verification URL
            var verificationUrlModel = await (_accounts[platformAccount.AccountName].Authenticate());

            _logger.LogInformation("generated link for verification: " + verificationUrlModel.verification_uri_complete);

            // Return the complete verification URL
            return verificationUrlModel.verification_uri_complete;
        }

        // Initializes an Allegro account for authentication
        private void initializeAccount(PlatformAccount platformAccount)
        {
            // Create a new instance of AllegroApi and add it to the accounts dictionary
            AllegroApi allegroApi = null;

            if(platformAccount.RefreshToken != string.Empty)
                allegroApi = new AllegroApi(platformAccount.ClientID, platformAccount.ClientSecret, platformAccount.RefreshToken, HandleRefreshToken);
            else
                allegroApi = new AllegroApi(platformAccount.ClientID, platformAccount.ClientSecret, HandleRefreshToken);

            //przy ponownej autoryzacji usunie stary obiekt który nie został zautoryzowany by móc poprawnie przejsc autoryzacjie bez resetowania poola
            if (_accounts.ContainsKey(platformAccount.AccountName))
            {
                _accounts.Remove(platformAccount.AccountName);
                _accounts.Add(platformAccount.AccountName, allegroApi);
            }
            else
            {
                _accounts.Add(platformAccount.AccountName, allegroApi);
            }
        }

        private async Task initializeAccount(string AccountName)
        {
            if (_accounts.ContainsKey(AccountName)) return;

            PlatformAccount platformAccount = null;

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var platformAccountService = scope.ServiceProvider.GetRequiredService<IPlatformAccountService>();
                platformAccount = platformAccountService.GetByName(AccountName);
            }

            // Create a new instance of AllegroApi and add it to the accounts dictionary
            AllegroApi allegroApi = null;

            if (platformAccount.RefreshToken != string.Empty)
                allegroApi = new AllegroApi(platformAccount.ClientID, platformAccount.ClientSecret, platformAccount.RefreshToken, HandleRefreshToken);

            if (allegroApi == null) return;

            await allegroApi.RefreshAccesToken();
            //przy ponownej autoryzacji usunie stary obiekt który nie został zautoryzowany by móc poprawnie przejsc autoryzacjie bez resetowania poola

            _accounts.Add(platformAccount.AccountName, allegroApi);
            
            AssignRefreshToken(AccountName);

            System.Diagnostics.Debug.WriteLine($"Konto {AccountName} zostało stworzone");
        }

        // Checks if the access token for the specified account is valid
        public async Task<bool> CheckAccessToken(string AccountName)
        {
            bool access = true;

            // If the refresh token is empty, attempt to get a new access token
            if (!IsAuthorized(AccountName))
                access = await _accounts[AccountName].CheckForAccessToken(0);

            if(access)
                AssignRefreshToken(AccountName);

            return access;
        }

        public void AssignRefreshToken(string AccountName)
        {
            if (!IsAuthorized(AccountName)) return;

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HelpDesk_Menagment_TwiloContext>();

                var refreshToken = _accounts[AccountName].RefreshToken;

                //wydaje mi sie ze wydajniej jest wpierw sprawdzic czy dany refresh token danego rekordu jest różny i ewentualnie nastepnie pobrać rekord by zaktualizowac wartość
                //niż odrazu pobrać mimo ze może nie byc potrzeby aktualizowania
                //jeżeli refresh token jest taki sam to konczymy metode ze względu ze nie ma nic wiecej do zrobienia
                if (context.PlatformAccounts.Any(acc => acc.AccountName == AccountName && acc.RefreshToken == refreshToken))
                    return;

                var platformAccount = context.PlatformAccounts.Where(acc => acc.AccountName == AccountName).FirstOrDefault();

                platformAccount.RefreshToken = refreshToken;

                _logger.LogInformation($"Assing: {AccountName}   {refreshToken}");

                context.Update(platformAccount);

                context.SaveChanges();
            }
        }

        public AllegroApi GetAllegroApi(string AccountName)
        {
            initializeAccount(AccountName).Wait();

            if (_accounts.ContainsKey(AccountName))
            {
                System.Diagnostics.Debug.WriteLine(AccountName + "   " + _accounts[AccountName].IsAuthorized());
                return _accounts[AccountName];
            }

            return null;
        }

        public string[] GetAuthorizedAccounts()
        {
            return _accounts.Where(acc => acc.Value.RefreshToken != string.Empty).Select(acc => acc.Key).ToArray();
        }

        public bool IsAuthorized(string AccountName)
        {
            if (_accounts.ContainsKey(AccountName))
                return _accounts[AccountName].RefreshToken != string.Empty;
            return false;
        }
    }
}
