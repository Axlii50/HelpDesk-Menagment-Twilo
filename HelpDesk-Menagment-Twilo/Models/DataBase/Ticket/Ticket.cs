namespace HelpDesk_Menagment_Twilo.Models.DataBase
{
    public class Ticket
    {
        public string TicketID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


        public DateOnly DateofCreation { get; set; }

        public Ticket()
        {
            this.TicketID = Guid.NewGuid().ToString();
            this.DateofCreation = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
