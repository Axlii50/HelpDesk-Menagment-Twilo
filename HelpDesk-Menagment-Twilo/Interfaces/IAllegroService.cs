using Allegro_Api;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IAllegroService
    {
        Task<string> GetVerificationUri(PlatformAccount platformAccount);
        Task<bool> CheckAccessToken(string AccountName);
        AllegroApi GetAllegroApi(string AccountName);
        bool IsAuthorized(string AccountName);
    }
}
