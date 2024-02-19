using Microsoft.AspNetCore.Mvc;

namespace HelpDesk_Menagment_Twilo.Controllers.Magazine
{
    public class MagazinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
