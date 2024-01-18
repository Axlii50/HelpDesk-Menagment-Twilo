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
        private readonly HelpDesk_Menagment_TwiloContext _context;
        private readonly IPackageService _packageService;
        private readonly IOrderService orderService;
        private readonly IOfferService offerService;

        public PackagesController(HelpDesk_Menagment_TwiloContext context, IPackageService packageService, IOrderService orderService, IOfferService offerService)
        {
            _packageService = packageService;
            this.orderService = orderService;
            this.offerService = offerService;
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
                packages = _packageService.GetPackages(AccountID)
            };

            return View("~/Views/Packages/Index.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPackage([Bind("UserID,WayBillId")]string UserID, string WayBillId)
        {
            var packageinfo = _packageService.AddPackage(UserID, WayBillId);

            var detailedOrder = (await orderService.GetDetailedOrderById(packageinfo.PlatformAccount.AccountName, packageinfo.OrderId.ToString()));

            var ImageUrls = (await offerService.GetImagesOfOffers(packageinfo.PlatformAccount.AccountName, detailedOrder.lineItems.Select(item => item.offer.id).ToArray())).ToList();

            return Json(new { buyer = detailedOrder.buyer, lineItems = detailedOrder.lineItems, delivery = detailedOrder.delivery, invoice = detailedOrder.invoice, images = ImageUrls });
        }
    }
}
