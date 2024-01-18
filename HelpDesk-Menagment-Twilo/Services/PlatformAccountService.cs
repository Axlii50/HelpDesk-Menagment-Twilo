using HelpDesk_Menagment_Twilo.Data;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Migrations;
using HelpDesk_Menagment_Twilo.Models.DataBase.Menagment;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Menagment_Twilo.Services
{
    public class PlatformAccountService : IPlatformAccountService
    {
        private readonly HelpDesk_Menagment_TwiloContext _context;

        public PlatformAccountService(HelpDesk_Menagment_TwiloContext context, IDeliveryRecognitionService recognition)
        {
            _context = context;
        }

        public List<PlatformAccount> GetAll()
        {
           return _context.PlatformAccounts.ToList();
        }

        public PlatformAccount GetByName(string AccountName)
        {
           return _context.PlatformAccounts.FirstOrDefault(pa => pa.AccountName == AccountName);
        }

        public Guid GetIdByName(string AccountName)
        {
            return _context.PlatformAccounts.Where(pa => pa.AccountName == AccountName).Select(pa => pa.ID).FirstOrDefault();
        }
    }
}
