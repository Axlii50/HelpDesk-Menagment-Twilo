using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Models
{
    public class MenagmentViewModel : IAccountID
    {
        public string AccountID { get; set; }
        public PermissionsTypes Permissions { get; set; }

        public List<PlatformAccount> PlatformAccounts { get; set; }
    }
}
