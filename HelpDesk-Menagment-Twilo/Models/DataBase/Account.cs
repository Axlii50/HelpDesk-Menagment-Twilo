using HelpDesk_Menagment_Twilo.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace HelpDesk_Menagment_Twilo.Models.DataBase
{
    public class Account: IIdentification
    {
        public Guid ID { get; set; }

        public PermissionsTypes Permissions { get; set; } = PermissionsTypes.HelpDesk;

        public string Login { get; set; }
        public string Password { get; set; }

        public Account()
        {
           
        }
    }

    public enum PermissionsTypes
    {
        HelpDesk = 1,
        HelpDeskAdmin = 2,
        Menagment = 4,
        MenagmentAdmin = 8,
        Packages = 16,
        PackagesAdmin = 32
    }
}
