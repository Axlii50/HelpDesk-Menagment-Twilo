using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public enum TicketCategory
    {
        Order = 5,
        Discussion = 10,
        Complaint = 15
    }
}
public static class TicketCategoryExstention
{
    public static string TranslatePL(this TicketCategory ticketStatus)
    {
        switch (ticketStatus)
        {
            case TicketCategory.Order: return "Zamówienie";
            case TicketCategory.Discussion: return "Dyskusja";
            case TicketCategory.Complaint: return "Reklamacje";
            default: return string.Empty;
        }
    }
}