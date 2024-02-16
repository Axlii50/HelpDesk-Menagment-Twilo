namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IProduct
    {
        string Author { get; set; }
        string EAN { get; set; }
        string ISBN { get; set; }
        string OutSideID { get; set; }
        string ImageName { get; set; }
        string IssueYear { get; set; }
        double PriceWholeSaleBrutto { get; set; }
        string Publisher { get; set; }
        string Title { get; set; }
    }
}