using Allegro_Api.Models.Order.checkoutform;
using Allegro_Api.Shipment.Components;
using Allegro_Api.Shipment;
using HelpDesk_Menagment_Twilo.Interfaces;

using Allegro_Api;
using Allegro_Api.Models.Shipment;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IAllegroService _allegroService;

        public ShippingService(IAllegroService allegroService)
        {
            _allegroService = allegroService;
        }

        public async Task<string> CreateShipment(string AccountName, string OrderId, string credentialsId)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var Order = await allegroapi.GetOrderDetails(OrderId);

            var Data = CreateShipmentData(Order);
            Data.input.credentialsId = credentialsId;

            allegroapi.CreatePackage(Data);

            //Dodawanie do bazy danych obiektu przypisanego do zamówienia zawierający Id odpowiedzialne za stworzenie paczki oraz co jakis czas wysyłanie zapytanie w celu prawdzenia status
            //Dodać osobny serwis pod Wysyłke paczek
            //throw new NotImplementedException();

            return Data.commandId;
        }

        private ShipmentObject CreateShipmentData(DetailedCheckOutForm detailedCheckOutForm)
        {
            var shipmentdata = new ShipmentCreateRequestDto()
            {
                deliveryMethodId = detailedCheckOutForm.delivery.method.id,
                credentialsId = string.Empty,
                sender = CreateSender(),
                receiver = CreateReceiver(ref detailedCheckOutForm),
                packages = CreatePackages(),
                cachOnDelivery = detailedCheckOutForm.delivery.method.name.Contains("pobranie") ? CreateCashOnDelivery(ref detailedCheckOutForm) : null,
            };

            var ShipmnetOject = new ShipmentObject()
            {
                commandId = Guid.NewGuid().ToString(),
                input = shipmentdata
            };

            return ShipmnetOject;
        }
        private CashOnDeliveryDto CreateCashOnDelivery(ref DetailedCheckOutForm detailedCheckOutForm)
        {
            return new CashOnDeliveryDto()
            {
                amount = detailedCheckOutForm.summary.totalToPay.amount,
                currency = detailedCheckOutForm.summary.totalToPay.currency,
                iban = "35 1870 1045 2078 1077 6763 0001",//przerzucic to do bazy danych
                ownerName = "TWILO SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ"
            };
        }
        private SenderAddressDto CreateSender()
        {
            return new SenderAddressDto()
            {
                company = "TWILO SP. Z O.O.",
                street = "ul. Gdyńska",
                streetNumber = "31",
                postalCode = "31-323",
                city = "Kraków",
                countryCode = "PL",
                email = "arkadiusz.kruszyna@twilo.pl",
                phone = "+48 577 940 100",
            };
        }
        private Packages[] CreatePackages()
        {
            return new Allegro_Api.Shipment.Components.Packages[]
            {
                new Allegro_Api.Shipment.Components.Packages()
                {
                    type = "PACKAGE",
                    weight = new Allegro_Api.Shipment.Components.WeightValue(){value = 10},
                    width = new Allegro_Api.Shipment.Components.DimensionValue(){value = 38},
                    height = new Allegro_Api.Shipment.Components.DimensionValue(){value = 8},
                    length = new Allegro_Api.Shipment.Components.DimensionValue(){value = 60}
                }
            };
        }
        private ReceiverAddressDto CreateReceiver(ref DetailedCheckOutForm detailedCheckOutForm)
        {
            return new ReceiverAddressDto()
            {
                name = detailedCheckOutForm.buyer.firstName + ' ' + detailedCheckOutForm.buyer.lastName,
                street = detailedCheckOutForm.delivery.address.streetAndNumber[0],
                streetNumber = detailedCheckOutForm.delivery.address.streetAndNumber?[1],//do ogarniecia jest złożony ticket na allegro github
                postalCode = detailedCheckOutForm.delivery.address.zipCode,
                city = detailedCheckOutForm.delivery.address.city,
                countryCode = detailedCheckOutForm.delivery.address.countryCode,
                email = detailedCheckOutForm.buyer.email,
                phone = detailedCheckOutForm.buyer.phoneNumber,
                point = detailedCheckOutForm.delivery.pickupPoint?.id
            };
        }

        private async Task<ShipmentCreationStatus> GetShipmentCreationStatus(string accountName ,string ShipmentCreationId)
        {
            var allegroApi = _allegroService.GetAllegroApi(accountName);

            return await allegroApi.CheckPackageCreationStatus(ShipmentCreationId);
        }
    }
}
