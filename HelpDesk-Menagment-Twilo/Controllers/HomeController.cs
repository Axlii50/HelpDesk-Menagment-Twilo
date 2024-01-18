using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Models;
using HelpDesk_Menagment_Twilo.Models.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace HelpDesk_Menagment_Twilo.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelpDesk_Menagment_TwiloContext helpDeskContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HelpDesk_Menagment_TwiloContext helpDesk_Menagment_TwiloContext)
        {
            _logger = logger;
            _logger.LogWarning("test");
            helpDeskContext = helpDesk_Menagment_TwiloContext;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login([Bind("login,password")]string login, string password)
        {
            var account = helpDeskContext.Account.Where(acc => acc.Login == login && acc.Password == password).FirstOrDefault();

            if (account == null)
                return View("~/Views/Home/LoginPage.cshtml");
            else
                return RedirectToAction("Index", "HelpDesk", new { AccountID = account.ID.ToString() });
        }
    }
}