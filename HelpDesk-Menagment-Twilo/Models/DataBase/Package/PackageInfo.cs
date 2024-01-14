using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Package
{
    public class PackageInfo : IIdentification
    {
        public Guid ID { get; set; }

        /// <summary>
        /// jeżeli package id 
        /// </summary>
        public string? PackageShippingId { get; set; }
        public string? CreationCommandID { get; set; }


        public Guid PlatformAccountId { get; set; }
        public PlatformAccount PlatformAccount { get; set; }

        public Guid OrderId { get; set; }

        public Guid? PackageId { get; set; }
        public Package? Package { get; set; }
    }
}
