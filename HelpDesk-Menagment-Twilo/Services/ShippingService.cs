using Allegro_Api.Models.Order.checkoutform;
using Allegro_Api.Shipment.Components;
using Allegro_Api.Shipment;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IAllegroService _allegroService;

        public ShippingService(IAllegroService allegroService)
        {
            _allegroService = allegroService;
        }

        public async void CreateShipment(string AccountName, string OrderId)
        {
            var allegroapi = _allegroService.GetAllegroApi(AccountName);

            var Order = await allegroapi.GetOrderDetails(OrderId);

            var Data = CreateShipmentData(Order);

            allegroapi.CreatePackage(Data);

            //Dodawanie do bazy danych obiektu przypisanego do zamówienia zawierający Id odpowiedzialne za stworzenie paczki oraz co jakis czas wysyłanie zapytanie w celu prawdzenia status
            //Dodać osobny serwis pod Wysyłke paczek
            throw new NotImplementedException();
        }

        private ShipmentObject CreateShipmentData(DetailedCheckOutForm detailedCheckOutForm)
        {
            var shipmentdata = new ShipmentCreateRequestDto()
            {
                deliveryMethodId = detailedCheckOutForm.delivery.method.id,
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
                currency = detailedCheckOutForm.summary.totalToPay.currency
            };
        }
        private SenderAddressDto CreateSender()
        {
            return new SenderAddressDto()
            {
                company = "TWILO SP. Z O.O.",
                street = "ul. Igołomska",
                streetNumber = "1/30",
                postalCode = "31-980",
                city = "Kraków",
                countryCode = "PL",
                email = "arkadiusz.kruszyna@twilo.pl",
                phone = "+48 572 353 814",
            };
        }
        private Packages[] CreatePackages()
        {
            return new Allegro_Api.Shipment.Components.Packages[]
            {
                new Allegro_Api.Shipment.Components.Packages()
                {
                    type = "PACKAGE",
                    weight = new Allegro_Api.Shipment.Components.WeightValue(){value = 25},
                    width = new Allegro_Api.Shipment.Components.DimensionValue(){value = 38},
                    height = new Allegro_Api.Shipment.Components.DimensionValue(){value = 8},
                    length = new Allegro_Api.Shipment.Components.DimensionValue(){value = 64}
                }
            };
        }
        private ReceiverAddressDto CreateReceiver(ref DetailedCheckOutForm detailedCheckOutForm)
        {
            return new ReceiverAddressDto()
            {
                name = detailedCheckOutForm.buyer.login,
                street = detailedCheckOutForm.delivery.address.streetAndNumber[0],
                streetNumber = detailedCheckOutForm.delivery.address.streetAndNumber[1],//do ogarniecia jest złożony ticket na allegro github
                postalCode = detailedCheckOutForm.delivery.address.zipCode,
                city = detailedCheckOutForm.delivery.address.city,
                countryCode = detailedCheckOutForm.delivery.address.countryCode,
                email = detailedCheckOutForm.buyer.email,
                phone = detailedCheckOutForm.buyer.phoneNumber,
            };
        }
    }
}
