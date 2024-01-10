﻿using Allegro_Api;
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

            _accounts.Add(platformAccount.AccountName, allegroApi);
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
            return _accounts[AccountName];
        }


        public string[] GetAuthorizedAccounts()
        {
            return _accounts.Keys.ToArray();
        }

        public bool IsAuthorized(string AccountName)
        {
            if (_accounts.ContainsKey(AccountName))
                return _accounts[AccountName].RefreshToken != string.Empty;
            else return false;
        }
    }
}
