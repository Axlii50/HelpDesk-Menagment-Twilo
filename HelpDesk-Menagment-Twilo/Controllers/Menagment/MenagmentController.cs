using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using HelpDesk_Menagment_Twilo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using Microsoft.AspNetCore.Http.Metadata;

namespace HelpDesk_Menagment_Twilo.Controllers.Menagment
{
    public class MenagmentController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;
        readonly IPlatformAccountService _platformAccountService;
        readonly IAllegroService _allegroService;


        public MenagmentController(HelpDesk_Menagment_TwiloContext context, IPlatformAccountService platformAccountService, IAllegroService allegroService)
        {
            _context = context;
            _platformAccountService = platformAccountService;
            _allegroService = allegroService;
        }

        public IActionResult Index(string AccountID)
        {
            var account = _context.Account.Find(new Guid(AccountID));

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var viewModel = new MenagmentViewModel()
            {
                AccountID = AccountID,
                Permissions = account.Permissions,
                PlatformAccounts = _platformAccountService.GetAll()
            };

            return View("~/Views/Menagment/Index.cshtml", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetVerificationUrl(string AccountID, string PlatformaccountName)
        {
            var account = _context.Account.Find(new Guid(AccountID));

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var PlatformAccount = _context.PlatformAccounts.Where(acc => acc.AccountName == PlatformaccountName).FirstOrDefault();

            string Url = await _allegroService.GetVerificationUri(PlatformAccount);

            return Json(new { Url = Url });
        }

        [HttpGet]
        public async Task<IActionResult> VerifyAccount(string AccountID, string PlatformaccountName)
        {
            var account = _context.Account.Find(new Guid(AccountID));

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            bool IsVerified = await _allegroService.CheckAccessToken(PlatformaccountName);

            return Json(new { IsVerified = IsVerified });
        }
    }
}
