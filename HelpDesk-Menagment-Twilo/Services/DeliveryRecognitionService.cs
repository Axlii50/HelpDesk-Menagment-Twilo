using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Package;
using System.Text.RegularExpressions;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class DeliveryRecognitionService : IDeliveryRecognitionService
    {
        public DeliveryType Recognize(string PackageID)
        {
            if (IsInpostTrackingNumber(PackageID)) return DeliveryType.Inpost;
            if (IsAllegroOneTrackingNumber(PackageID)) return DeliveryType.AllegroOne;
            if (IsOrlenTrackingNumber(PackageID)) return DeliveryType.Orlen;

            return 0;
        }

        bool IsInpostTrackingNumber(string trackingNumber)
        {
            return Regex.IsMatch(trackingNumber, @"^6319\d{20}$");
        }

        bool IsAllegroOneTrackingNumber(string trackingNumber)
        {
            return Regex.IsMatch(trackingNumber, @"^A[A-Z0-9]{9}$");
        }

        bool IsOrlenTrackingNumber(string trackingNumber)
        {
            return Regex.IsMatch(trackingNumber, @"^21\d{11}$");
        }
    }
}
