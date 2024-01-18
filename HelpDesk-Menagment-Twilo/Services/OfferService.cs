using Allegro_Api.Models.Offer;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Migrations;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class OfferService : IOfferService
    {
        private readonly IAllegroService _allegroService;

        public OfferService(IAllegroService allegroService )
        {
            this._allegroService = allegroService;
        }

        public async Task<IEnumerable<string>> GetImagesOfOffers(string accountName, string[] offerIds)
        {
            var allegroapi = _allegroService.GetAllegroApi(accountName);

            var offers = (await allegroapi.GetSpecifiedOffers(offerIds)).Select(off => off.primaryImage["url"]);

            return offers;
        }
    }
}
