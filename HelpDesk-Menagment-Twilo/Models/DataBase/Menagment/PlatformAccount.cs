using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Menagment
{
    public class PlatformAccount : IIdentification
    {
        public Guid ID { get; set; }

        public string AccountName { get; set; }

        public string ClientSecret { get; set; }

        public string ClientID { get; set; }

        public PlatformType PlatformType { get; set; }
    }

    public enum PlatformType
    {
        Allegro = 1
    }
}
