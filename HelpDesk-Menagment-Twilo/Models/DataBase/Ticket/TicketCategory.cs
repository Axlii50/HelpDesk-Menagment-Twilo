using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;

namespace HelpDesk_Menagment_Twilo.Models.DataBase.Ticket
{
    public enum TicketCategory
    {
        Order = 5,
        Discussion = 10,
        Return = 15,
        Invoice = 20,
        WholeSeller = 25,
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
            case TicketCategory.Return: return "Zwrot";
            case TicketCategory.Invoice: return "Faktura";
            case TicketCategory.WholeSeller: return "Hurtownia";
            default: return string.Empty;
        }
    }
}