using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Models.DataBase;

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
