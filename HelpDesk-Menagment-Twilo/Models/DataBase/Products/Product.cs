using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Products
{
    public class Product : IProduct, IIdentification
    {
        public string Author { get; set; }
        public string EAN { get; set; }
        public string OutSideID { get; set; }
        public WholeSellerType wholeSellerType { get; set; }
        public string ImageName { get; set; }
        public string ISBN { get; set; }
        public string IssueYear { get; set; }
        public double PriceWholeSaleBrutto { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }

        public Guid ID { get; set; }
    }

    public enum WholeSellerType
    {
        Liber = 0,
        Ateneum = 5,
        Azymut = 10,
        Zysk = 15
    }
}
