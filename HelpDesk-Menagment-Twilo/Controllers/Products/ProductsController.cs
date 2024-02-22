using Microsoft.AspNetCore.Mvc;

namespace HelpDesk_Menagment_Twilo.Controllers.Products
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Products/index.cshtml");
        }
    }
}
