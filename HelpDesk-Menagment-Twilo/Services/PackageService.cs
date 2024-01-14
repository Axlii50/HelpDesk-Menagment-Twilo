﻿using Allegro_Api.Models.Order.checkoutform;
using Allegro_Api.Shipment;
using Allegro_Api.Shipment.Components;
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
        private readonly IAllegroService _allegroService;

        public PackageService(HelpDesk_Menagment_TwiloContext context, IDeliveryRecognitionService recognition, IAllegroService allegroService)
        {
            _context = context;
            _recognition = recognition;
            _allegroService = allegroService;
        }

        public IActionResult AddPackage(string UserID, string PackageID)
        {
            var packageinfo = GetPackageInfo(PackageID);
            //jeżeli jakimś cudem null w takim wypadku pobrać etykiete dla danej paczki oraz wszelkie informacje odnośnie zamówienia

            var package = new Package()
            {
                PackageInfo = packageinfo,
                AccountID = new Guid(UserID),
                //DeliveryType = _recognition.Recognize(PackageID)
            };

            _context.Packages.Add(package);

            _context.SaveChanges();

            return new OkResult();
        }
        
        public PackageInfo GetPackageInfo(string PackageShippingId)
        {
            return _context.PackageInfo.SingleOrDefault(info => info.PackageShippingId == PackageShippingId);
        }

        public IEnumerable<Package> GetPackages(string UserID)
        {
            return (_context.Packages.Include(pack => pack.Account).Include(pack => pack.PackageInfo).Where(pack => pack.AccountID.ToString() == UserID).ToList());
        }

        public IEnumerable<Package> GetPackages(string UserID, int number)
        {
            return (_context.Packages.Include(pack => pack.Account).Include(pack => pack.PackageInfo).Where(pack => pack.AccountID.ToString() == UserID).Take(number).ToList());
        }

        public async Task<bool> CheckIfPackageInfoExist(Guid PackageInfoID)
        {
            return await _context.PackageInfo.AnyAsync(pack => pack.OrderId == PackageInfoID);
        }

        public void AddPackageInfo(PackageInfo packageInfo)
        {
            _context.PackageInfo.Add(packageInfo);
            _context.SaveChanges();
        }
    }
}
