using Microsoft.AspNetCore.Mvc;

namespace HelpDesk_Menagment_Twilo.Controllers.HelpDesk
{
    public class HelpDesk : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
