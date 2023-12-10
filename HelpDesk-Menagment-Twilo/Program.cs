using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelpDesk_Menagment_Twilo.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using HelpDesk_Menagment_Twilo.Models.DataBase.Ticket;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
    //https://stackoverflow.com/questions/21460146/fire-javascript-function-2-sec-after-no-activity-in-input-tag
    public static class HtmlHelper
    {
        public static List<SelectListItem> TicketCategoryGetList()
        {
            var list = Enum.GetValues(typeof(TicketCategory)).Cast<TicketCategory>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();
            return list;
        }
        public static List<SelectListItem> TicketStatusGetList()
        {
            var list = Enum.GetValues(typeof(TicketStatus)).Cast<TicketStatus>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString(),
            }).ToList();
            return list;
        }
        public static List<SelectListItem> TicketPriorityGetList()
        {
            var list = Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();
            return list;
        }

        public static List<SelectListItem> TicketCategoryGetList(TicketCategory category)
        {
            var list = Enum.GetValues(typeof(TicketCategory)).Cast<TicketCategory>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();

            foreach (var item in list)
                if(item.Value == ((int)category).ToString())
                    item.Selected = true;

            return list;
        }
        public static List<SelectListItem> TicketStatusGetList(TicketStatus ticketStatus)
        {
            var list = Enum.GetValues(typeof(TicketStatus)).Cast<TicketStatus>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString(),
            }).ToList();

            foreach (var item in list)
                if (item.Value == ((int)ticketStatus).ToString())
                    item.Selected = true;

            return list;
        }
        public static List<SelectListItem> TicketPriorityGetList(TicketPriority ticketPriority)
        {
            var list = Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>().Select(v => new SelectListItem
            {
                Text = v.TranslatePL(),
                Value = ((int)v).ToString()
            }).ToList();

            foreach (var item in list)
                if (item.Value == ((int)ticketPriority).ToString())
                    item.Selected = true;

            return list;
        }
    }
}