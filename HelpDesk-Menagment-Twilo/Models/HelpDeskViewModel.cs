using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models
{
    public class HelpDeskViewModel
    {
        public string AccountID { get; set; }

        public Dictionary<TicketCategory, List<Ticket>> Tickets { get; set; }
    }
}
