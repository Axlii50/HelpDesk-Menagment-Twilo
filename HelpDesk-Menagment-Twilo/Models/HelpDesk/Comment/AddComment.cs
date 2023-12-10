using HelpDesk_Menagment_Twilo.Models.DataBase;

namespace HelpDesk_Menagment_Twilo.Models.HelpDesk.Comment
{
    public class AddComment : IAccountID
    {
        //ids
        public string AccountID { get; set; }
        public string TicketID { get; set; }

        public string CommentTitle { get; set; }
        public string CommentDescription { get; set; }
        PermissionsTypes IAccountID.Permissions { get; set; }
    }
}
