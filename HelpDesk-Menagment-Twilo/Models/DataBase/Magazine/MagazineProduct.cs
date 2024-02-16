using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Magazine
{
    public class MagazineProduct : IIdentification
    { 
        public Guid ID { get; set; }
        public string Ean { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string MagazinCount { get; set; }
    }
}
