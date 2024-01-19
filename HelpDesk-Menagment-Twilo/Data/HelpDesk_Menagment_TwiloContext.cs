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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //modelBuilder.Entity<Package>()
            //    .HasOne(p => p.PackageInfo)
            //    .WithMany()
            //    .HasForeignKey(p => p.PackageInfoId)
            //    .OnDelete(DeleteBehavior.NoAction); // Set the desired OnDelete behavior

            // Additional configurations for other entities and relationships

            base.OnModelCreating(modelBuilder);
        }
    }
}
