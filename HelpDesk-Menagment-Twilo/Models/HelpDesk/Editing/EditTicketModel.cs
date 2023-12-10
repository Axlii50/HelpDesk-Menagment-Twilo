using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.HelpDesk.Editing
{
    public class EditTicketModel : IAccountID
    {
        public string AccountID { get; set; }
        public string TicketID { get; set; }

        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }

        public TicketCategory TicketCategory { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public TicketPriority TicketPriority { get; set; }
        PermissionsTypes IAccountID.Permissions { get; set; }
    }
}
