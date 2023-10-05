using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public class TicketComment
    {
        [Key]
        public string TicketCommentID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string DateofCreation { get; set; }
        public string CommentCreatorName { get; set; }

        public TicketComment(string commentCreatorName)
        {
            this.TicketCommentID = Guid.NewGuid().ToString();
            this.DateofCreation = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("H:mm");
            this.CommentCreatorName = commentCreatorName;
        }
    }
}
