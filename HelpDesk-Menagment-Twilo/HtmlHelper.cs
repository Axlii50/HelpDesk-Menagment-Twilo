using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpDesk_Menagment_Twilo
{
    //https://stackoverflow.com/questions/21460146/fire-javascript-function-2-sec-after-no-activity-in-input-tag
    public static class HtmlHelper
    {
        public static List<SelectListItem> TicketCategoryGetList()
        {
            var list = Enum.GetValues(typeof(TicketCategory)).Cast<TicketCategory>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();
            return list;
        }
        public static List<SelectListItem> TicketStatusGetList()
        {
            var list = Enum.GetValues(typeof(TicketStatus)).Cast<TicketStatus>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString(),
            }).ToList();
            return list;
        }
        public static List<SelectListItem> TicketPriorityGetList()
        {
            var list = Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();
            return list;
        }

        public static List<SelectListItem> TicketCategoryGetList(TicketCategory category)
        {
            var list = Enum.GetValues(typeof(TicketCategory)).Cast<TicketCategory>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();

            foreach (var item in list)
                if(item.Value == ((int)category).ToString())
                    item.Selected = true;

            return list;
        }
        public static List<SelectListItem> TicketStatusGetList(TicketStatus ticketStatus)
        {
            var list = Enum.GetValues(typeof(TicketStatus)).Cast<TicketStatus>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString(),
            }).ToList();

            foreach (var item in list)
                if (item.Value == ((int)ticketStatus).ToString())
                    item.Selected = true;

            return list;
        }
        public static List<SelectListItem> TicketPriorityGetList(TicketPriority ticketPriority)
        {
            var list = Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();

            foreach (var item in list)
                if (item.Value == ((int)ticketPriority).ToString())
                    item.Selected = true;

            return list;
        }
    }
}