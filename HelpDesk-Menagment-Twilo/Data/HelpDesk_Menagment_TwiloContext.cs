using HelpDesk_Menagment_Twilo.Models.DataBase.Package;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Menagment_Twilo.Data
{
    public class HelpDesk_Menagment_TwiloContext : DbContext
    {
        public HelpDesk_Menagment_TwiloContext (DbContextOptions<HelpDesk_Menagment_TwiloContext> options)
            : base(options)
        {
        }

        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Account> Account { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Menagment.PlatformAccount> PlatformAccounts { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket> Ticket { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.TicketComment> TicketComments { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Package.Package> Packages { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Package.PackageInfo> PackageInfo { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.Products.Product> Products { get; set; } = default!;
        public DbSet<HelpDesk_Menagment_Twilo.Models.DataBase.WareHouse.WareHouseProduct> WareHouseProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
