using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.HelpDesk.AddingTicket
{
    public class AddTicketModel
    {
        public string AccountID { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }

        public TicketCategory TicketCategory { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public TicketPriority TicketPriority { get; set; }
    }
}
