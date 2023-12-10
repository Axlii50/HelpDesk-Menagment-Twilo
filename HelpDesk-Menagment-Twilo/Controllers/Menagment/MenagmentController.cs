using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using HelpDesk_Menagment_Twilo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Data;

namespace HelpDesk_Menagment_Twilo.Controllers.Menagment
{
    public class MenagmentController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;

        public MenagmentController(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
        }

        public IActionResult Index(string AccountID)
        {
            var account = _context.Account.Find(AccountID);

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var viewModel = new MenagmentViewModel()
            {
                AccountID = AccountID,
                Permissions = account.Permissions
            };
           

            return View("~/Views/Menagment/Index.cshtml", viewModel);
        }
    }
}
