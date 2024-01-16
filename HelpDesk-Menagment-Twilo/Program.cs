using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelpDesk_Menagment_Twilo.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using HelpDesk_Menagment_Twilo.Interfaces;
using HelpDesk_Menagment_Twilo.Services;
using Microsoft.Extensions.Hosting;

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

            builder.Services.AddMemoryCache();

            builder.Services.AddHostedService<BackGroundService>();
            builder.Services.AddSingleton<IBackGroundService, PackageGeneratorService>();
            builder.Services.AddSingleton<IBackGroundService, PackageCheckerService>();

            builder.Services.AddSingleton<IAllegroService, AllegroService>();

            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddScoped<IDeliveryRecognitionService, DeliveryRecognitionService>();
            builder.Services.AddScoped<IPlatformAccountService, PlatformAccountService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IShippingService, ShippingService>();
            builder.Services.AddScoped<IDeliveryServicesService, DeliveryServicesService>();
            builder.Services.AddScoped<IOfferService, OfferService>();

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