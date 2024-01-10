using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using HelpDesk_Menagment_Twilo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Models.Package;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Controllers.Packages
{
    public class PackagesController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;
        readonly IPackageService _packageService;

        public PackagesController(HelpDesk_Menagment_TwiloContext context, IPackageService packageService)
        {
            _packageService = packageService;
            _context = context;
        }

        public IActionResult Index(string AccountID)
        {
            if(AccountID == null) return View("~/Views/Home/LoginPage.cshtml");

            var account = _context.Account.Find(new Guid(AccountID));

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var viewModel = new PackageViewModel()
            {
                AccountID = AccountID,
                Permissions = account.Permissions,
               // packages = _packageService.GetPackages(AccountID)
            };

            return View("~/Views/Packages/Index.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult AddPackage([Bind("UserID,PackageID")]string UserID, string PackageID)
        {
            return _packageService.AddPackage(UserID, PackageID);
        }
    }
}
