﻿// <auto-generated />
using HelpDesk_Menagment_Twilo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    [DbContext(typeof(HelpDesk_Menagment_TwiloContext))]
    [Migration("20231005213933_CommentCreator2")]
    partial class CommentCreator2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Account", b =>
                {
                    b.Property<string>("AccountID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", b =>
                {
                    b.Property<string>("TicketID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("DateofCreation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketID");

                    b.HasIndex("AccountID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.TicketComment", b =>
                {
                    b.Property<string>("TicketCommentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentCreatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateofCreation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketCommentID");

                    b.HasIndex("TicketID");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", b =>
                {
                    b.HasOne("HelpDesk_Menagment_Twilo.Models.DataBase.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.TicketComment", b =>
                {
                    b.HasOne("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", null)
                        .WithMany("Comments")
                        .HasForeignKey("TicketID");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
