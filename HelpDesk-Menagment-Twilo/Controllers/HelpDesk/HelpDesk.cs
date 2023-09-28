using Microsoft.AspNetCore.Mvc;

namespace HelpDesk_Menagment_Twilo.Controllers.HelpDesk
{
    [NoDirectAccess]
    public class HelpDesk : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
