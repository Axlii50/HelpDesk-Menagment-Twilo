using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Package
{
    public class PackageInfo : IIdentification
    {
        public Guid ID { get; set; }

        /// <summary>
        /// Generated shipment ID
        /// </summary>
        public string? PackageShippingId { get; set; }
        /// <summary>
        /// numer przesyłki
        /// </summary>
        public string? PackageWayBill { get; set; }
        public string? CreationCommandID { get; set; }
        public CreationCommandType CreationCommandType { get; set; } = CreationCommandType.In_Progres;

        public Guid PlatformAccountId { get; set; }
        public PlatformAccount PlatformAccount { get; set; }

        public Guid OrderId { get; set; }

        public Guid? PackageId { get; set; }
        public Package? Package { get; set; }
    }

    public enum CreationCommandType
    {
        In_Progres,
        Success,
        Error
    }
}
