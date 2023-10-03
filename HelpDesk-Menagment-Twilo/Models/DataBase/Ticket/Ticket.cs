using HelpDesk_Menagment_Twilo.Models.HelpDesk.AddingTicket;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public class Ticket
    {
        [Key]
        public string TicketID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public TicketCategory Category { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }


        [ForeignKey("Account")]
        public string AccountID { get; set; }
        public Account Account { get; set; }
        
        public List<TicketComment> Comments { get; set; } = new List<TicketComment>();

        public string DateofCreation { get; set; }

        public Ticket()
        {
            this.TicketID = Guid.NewGuid().ToString();
            this.DateofCreation = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("H:mm");
        }

        public static Ticket operator +(Ticket ticket, AddTicketModel addTicket)
        {
            ticket.Title = addTicket.TicketTitle;
            ticket.Description = addTicket.TicketDescription;
            ticket.Status = addTicket.TicketStatus;
            ticket.Category = addTicket.TicketCategory;
            ticket.Priority = addTicket.TicketPriority;
            ticket.AccountID = addTicket.AccountID;

            return ticket;
        }
    }
}
