using HelpDesk_Menagment_Twilo.Migrations;
using HelpDesk_Menagment_Twilo.Models.DataBase;

namespace HelpDesk_Menagment_Twilo.Models.Package
{
    public class PackageViewModel : IAccountID
    {
        public string AccountID { get ; set ; }
        public PermissionsTypes Permissions { get; set; }
        public IEnumerable<Models.DataBase.Package.Package> packages { get; set; } 
    }
}
