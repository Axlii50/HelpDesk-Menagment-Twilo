using Allegro_Api.Models.Offer;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IOfferService
    {
        Task<IEnumerable<string>> GetImagesOfOffers(string accountName, string[] offerIds);

    }
}