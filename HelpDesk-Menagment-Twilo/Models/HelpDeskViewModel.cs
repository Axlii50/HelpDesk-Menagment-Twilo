using HelpDesk_Menagment_Twilo.Models.DataBase;
using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Menagment_Twilo.Models
{
    public class HelpDeskViewModel: IAccountID
    {
        public string AccountID { get; set; }
        public Dictionary<TicketCategory, List<Ticket>> Tickets { get; set; }
        public PermissionsTypes Permissions { get; set; }
    }
}
