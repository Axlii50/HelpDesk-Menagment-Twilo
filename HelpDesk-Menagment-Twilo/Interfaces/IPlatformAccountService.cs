using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IPlatformAccountService
    {
        List<PlatformAccount> GetAll();
        PlatformAccount GetByName(string AccountName);
        Guid GetIdByName(string AccountName);
    }
}
