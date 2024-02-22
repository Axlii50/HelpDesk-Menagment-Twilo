using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;
using HelpDesk_Menagment_Twilo.Models.Magazine;
using HelpDesk_Menagment_Twilo.Models.Menagment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Menagment_Twilo.Controllers.Magazine
{
    public class MagazinController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;
        readonly IPlatformAccountService _platformAccountService;
        readonly IAllegroService _allegroService;

        public MagazinController(HelpDesk_Menagment_TwiloContext context,
           IPlatformAccountService platformAccountService,
           IAllegroService allegroService)
        {
            _context = context;
            _platformAccountService = platformAccountService;
            _allegroService = allegroService;
        }

        public IActionResult Index(string AccountID)
        {
            var account = _context.Account.Find(new Guid(AccountID));

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var viewModel = new MagazineViewModel()
            {
                AccountID = AccountID,
                Permissions = account.Permissions
            };

            return View("~/Views/Magazine/Index.cshtml", viewModel);
        }
    }
}
