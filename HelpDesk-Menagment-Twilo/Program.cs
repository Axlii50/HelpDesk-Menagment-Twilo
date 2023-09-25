using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelpDesk_Menagment_Twilo.Data;
namespace HelpDesk_Menagment_Twilo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HelpDesk_Menagment_TwiloContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HelpDesk_Menagment_TwiloContext") ?? throw new InvalidOperationException("Connection string 'HelpDesk_Menagment_TwiloContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=LoginPage}/{id?}");

            app.Run();
        }
    }
}