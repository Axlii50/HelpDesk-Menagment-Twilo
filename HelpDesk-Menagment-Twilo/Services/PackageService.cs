using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Package;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageService : IPackageService
    {
        private readonly HelpDesk_Menagment_TwiloContext _context;
        private readonly IDeliveryRecognitionService _recognition;

        public PackageService(HelpDesk_Menagment_TwiloContext context, IDeliveryRecognitionService recognition)
        {
            _context = context;
            _recognition = recognition;
        }

        public IActionResult AddPackage(string UserID, string PackageID)
        {
            var package = new Package()
            {
                PackageShippingID = PackageID,
                AccountID = new Guid(UserID),
            };

            //dodanie rozpoznawania typu dostawcy
            //package.DeliveryType = _recognition.Recognize(PackageID);

            _context.Packages.Add(package);

            _context.SaveChanges();

            return new OkResult();
        }

        public IEnumerable<Package> GetPackages(string UserID)
        {
            return (_context.Packages.Include(pack => pack.Account).Where(pack => pack.AccountID.ToString() == UserID)/*.Select(pack => pack.Account.Login)*/.ToList());
        }

        public IEnumerable<Package> GetPackages(string UserID, int number)
        {
            throw new NotImplementedException();
        }
    }
}
