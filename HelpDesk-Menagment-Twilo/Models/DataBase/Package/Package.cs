using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Package
{
    public class Package
    {
        public string PackageID { get; set; }

        public string PackageShippingID { get; set; }

        public string DateString { get; set; }


        [ForeignKey("Account")]
        public string AccountID { get; set; }
        public Account Account { get; set; }
    }
}
