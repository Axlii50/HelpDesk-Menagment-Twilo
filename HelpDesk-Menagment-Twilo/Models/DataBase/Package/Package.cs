using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Package
{
    public class Package : IIdentification
    {
        public Guid ID { get; set; }

        public string PackageShippingID { get; set; }

        public string DateString { get; set; }

        public DeliveryType DeliveryType { get; set; }

        [ForeignKey("Account")]
        public Guid AccountID { get; set; }
        public Account Account { get; set; }
        
    }

    public enum DeliveryType
    {
        Inpost = 1,
        DPD = 2,
        AllegroOne = 4,
        Orlen = 8,
        UPS = 16,
    }
}
