using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Package;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PackageService : IPackageService
    {
        private readonly HelpDesk_Menagment_TwiloContext _context;

        public PackageService(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
        }


        public void AddPackage(string UserID, string PackageID)
        {
            
        }

        public IEnumerable<Package> GetPackages(string UserID)
        {
            throw new NotImplementedException();
        }
    }
}
