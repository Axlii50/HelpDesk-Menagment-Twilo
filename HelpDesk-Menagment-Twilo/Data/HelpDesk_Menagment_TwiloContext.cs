using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDesk_Menagment_Twilo.Models.DataBase;

namespace HelpDesk_Menagment_Twilo.Data
{
    public class HelpDesk_Menagment_TwiloContext : DbContext
    {
        public HelpDesk_Menagment_TwiloContext (DbContextOptions<HelpDesk_Menagment_TwiloContext> options)
            : base(options)
        {
        }

        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Account> Account { get; set; } = default!;
    }
}
