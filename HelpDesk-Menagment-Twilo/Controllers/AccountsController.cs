using Microsoft.AspNetCore.Mvc;
using HelpDesk_Menagment_Twilo.Data;

namespace HelpDesk_Menagment_Twilo.Controllers
{
    public class AccountsController : Controller
    {
        private readonly HelpDesk_Menagment_TwiloContext _context;

        public AccountsController(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
        }

    
       
    }
}
