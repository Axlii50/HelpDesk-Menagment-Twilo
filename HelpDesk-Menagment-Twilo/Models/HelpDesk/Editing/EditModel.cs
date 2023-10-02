using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.HelpDesk.Editing
{
    public class EditModel
    {
        public string AccountID { get; set; }
        public string TicketID { get; set; }

        public Ticket Ticket { get; set; }
    }
}
