
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

        public string DateofCreation { get; set; }

        public Ticket()
        {
            this.TicketID = Guid.NewGuid().ToString();
            this.DateofCreation = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("H:mm");
        }
    }
}
