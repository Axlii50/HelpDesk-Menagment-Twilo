using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using HelpDesk_Menagment_Twilo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Controllers.Menagment
{
    public class MenagmentController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;
        readonly IPlatformAccountService _platformAccountService;


        public MenagmentController(HelpDesk_Menagment_TwiloContext context, IPlatformAccountService platformAccountService)
        {
            _context = context;
            _platformAccountService = platformAccountService;
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
    }
}
