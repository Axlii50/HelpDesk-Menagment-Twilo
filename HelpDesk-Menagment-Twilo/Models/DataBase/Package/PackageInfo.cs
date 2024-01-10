using HelpDesk_Menagment_Twilo.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Package
{
    public class PackageInfo : IIdentification
    {
        public Guid ID { get; set; }

        /// <summary>
        /// jeżeli package id 
        /// </summary>
        public string PackageShippingId { get; set; }
        public string CreationCommandID { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("Package")]
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
    }
}
