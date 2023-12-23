using HelpDesk_Menagment_Twilo.Models.DataBase.Package;

namespace HelpDesk_Menagment_Twilo.Interfaces
{
    public interface IPackageService
    {
        void AddPackage();

        IEnumerable<Package> GetPackages(string UserID);

    }
}
