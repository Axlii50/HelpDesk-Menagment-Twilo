using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Models;
using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using HelpDesk_Menagment_Twilo.Models.HelpDesk.AddingTicket;
using HelpDesk_Menagment_Twilo.Models.HelpDesk.Editing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NuGet.Protocol.Plugins;
using System.Net.Sockets;
using System.Security.Principal;

namespace HelpDesk_Menagment_Twilo.Controllers.HelpDesk
{
    [NoDirectAccess]
    public class HelpDeskController : Controller
    {
        readonly HelpDesk_Menagment_TwiloContext _context;

        public HelpDeskController(HelpDesk_Menagment_TwiloContext context)
        {
            _context = context;
        }

        public IActionResult Index(string AccountID)
        {
            var account = _context.Account.Find(AccountID);

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var viewModel = new HelpDeskViewModel()
            {
                AccountID = AccountID,
                Tickets = new Dictionary<TicketCategory, List<Ticket>>()
            };

            foreach (TicketCategory type in Enum.GetValues<TicketCategory>())
            {
                var Tickets = _context.Ticket.Where(tick => tick.Status != TicketStatus.Completed && tick.Category == type).ToList();
                viewModel.Tickets.Add(type, Tickets);
            }

            return View("~/Views/HelpDesk/Index.cshtml", viewModel);
        }


        #region Tickets
        public async Task<IActionResult> AddTicket([Bind("TicketTitle,TicketDescription,TicketCategory,TicketStatus,TicketPriority,AccountID")] AddTicketModel ticket)
        {
            var account = _context.Account.Find(ticket.AccountID);

            if (account == null) return BadRequest();

            Ticket ticketModel = new Ticket() + ticket;
            ticketModel.Account = account;

            _context.Ticket.Add(ticketModel);
            await _context.SaveChangesAsync();

            return Index(account.AccountID);
        }

        public async Task<IActionResult> DeleteTicket(string AccountID, string TicketID)
        {
            var ticket = _context.Ticket.Find(TicketID);

            if (ticket == null) return Index(AccountID);

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return Index(AccountID);
        }

      
        public IActionResult EditTicket(string AccountID, string TicketID)
        {
            var account = _context.Account.Find(AccountID);

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var ticket = _context.Ticket.Find(TicketID);

            if (ticket == null) return Index(AccountID);

            EditModel editModel = new EditModel()
            {
                AccountID = account.AccountID,
                TicketID = ticket.TicketID,
                Ticket = ticket
            };

            return View("~/Views/HelpDesk/Edit.cshtml", editModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditTicket([Bind("TicketTitle,TicketDescription,TicketCategory,TicketStatus,TicketPriority,AccountID,TicketID")] Models.HelpDesk.Editing.EditTicketModel ticket)
        {
            var account = _context.Account.Find(ticket.AccountID);

            if (account == null) return View("~/Views/Home/LoginPage.cshtml");

            var ticketEntity = _context.Ticket.Find(ticket.TicketID);

            if (ticketEntity == null) return Index(ticket.AccountID);

            ticketEntity.Status = ticket.TicketStatus;
            ticket.TicketCategory = ticket.TicketCategory;
            ticket.TicketPriority = ticket.TicketPriority;
            ticketEntity.Description = ticket.TicketDescription;
            ticketEntity.Title = ticket.TicketTitle;
          
            await _context.SaveChangesAsync();

            return Index(account.AccountID);
        }

        #endregion
    }
}
