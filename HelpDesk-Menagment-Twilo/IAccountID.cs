using HelpDesk_Menagment_Twilo.Models.DataBase;

namespace HelpDesk_Menagment_Twilo
{
    public interface IAccountID
    {
        public string AccountID { get; set; }

        public PermissionsTypes Permissions { get; set; }
    }
}
