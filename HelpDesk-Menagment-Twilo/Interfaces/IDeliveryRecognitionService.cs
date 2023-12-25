using HelpDesk_Menagment_Twilo.Models.DataBase.Package;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IDeliveryRecognitionService
    {
        DeliveryType Recognize(string PackageID);
    }
}
