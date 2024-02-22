using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;

namespace HelpDesk_Menagment_Twilo.Models.WareHouse
{
    public class WareHouseViewModel : IAccountID
    {
        public string AccountID { get; set; }
        public PermissionsTypes Permissions { get; set; }

    }
}
