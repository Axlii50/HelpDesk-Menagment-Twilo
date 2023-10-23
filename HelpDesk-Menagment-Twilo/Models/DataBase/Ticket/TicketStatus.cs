using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public enum TicketStatus
    {
        New = 5,
        InProgress = 10,
        Halted = 15,
        Completed = 20
    }
    
}

public static class TicketStatusExstention
{
    public static string TranslatePL(this TicketStatus ticketStatus)
    {
        switch (ticketStatus)
        {
            case TicketStatus.New: return "Nowe";
            case TicketStatus.InProgress: return "W trakcie";
            case TicketStatus.Completed: return "Zakończone";
            case TicketStatus.Halted: return "Wstrzymane";
            default: return string.Empty;
        }
    }
}