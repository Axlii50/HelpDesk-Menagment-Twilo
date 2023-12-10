using System.ComponentModel.DataAnnotations;
using System.Security;

namespace HelpDesk_Menagment_Twilo.Models.DataBase
{
    public class Account
    {
        [Key]
        public string AccountID { get; set; }

        public PermissionsTypes Permissions { get; set; } = PermissionsTypes.HelpDesk;

        public string Login { get; set; }
        public string Password { get; set; }

        public Account()
        {
            this.AccountID = Guid.NewGuid().ToString();
        }
    }

    public enum PermissionsTypes
    {
        HelpDesk = 1,
        Menagment = 2,
        Packages = 4
    }
}
