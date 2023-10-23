using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public enum TicketPriority
    {
        Yesterday = 0,
        Instant = 5,
        Fast = 10,
        Normal = 15,
        NotImportant = 20,
    }

   
}


public static class TicketPriorityExstention
{
    public static string TranslatePL(this TicketPriority ticketStatus)
    {
        switch (ticketStatus)
        {
            case TicketPriority.Yesterday: return "Na wczoraj";
            case TicketPriority.Instant: return "Natychmiast";
            case TicketPriority.Fast: return "Szybko";
            case TicketPriority.Normal: return "Normalne";
            case TicketPriority.NotImportant: return "Mało ważne";
            default: return string.Empty;
        }
    }
}