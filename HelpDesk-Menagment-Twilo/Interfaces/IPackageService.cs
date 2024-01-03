using HelpDesk_Menagment_Twilo.Models.DataBase.Package;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IPackageService
    {
        IActionResult AddPackage(string UserID, string PackageID);

        IEnumerable<Package> GetPackages(string UserID);

        IEnumerable<Package> GetPackages(string UserID, int number);

        PackageInfo GetPackageInfo(string PackageShippingId);

        void CreatePackage();
    }
}
