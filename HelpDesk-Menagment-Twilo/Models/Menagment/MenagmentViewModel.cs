using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Models.Menagment
{
    public class MenagmentViewModel : IAccountID
    {
        public string AccountID { get; set; }
        public PermissionsTypes Permissions { get; set; }

        public Dictionary<PlatformAccount, bool> PlatformAccountsWithAuthorizationStatus { get; set; }
        //public List<bool> IsCorrespondingAccVerified { get; set; }
    }
}
