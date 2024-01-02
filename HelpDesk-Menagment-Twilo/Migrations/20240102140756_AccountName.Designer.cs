﻿// <auto-generated />
using System;
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
    [Migration("20240102140756_AccountName")]
    partial class AccountName
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
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permissions")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Menagment.PlatformAccount", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PlatformAccounts");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Package.Package", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Package.PackageInfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PackageShippingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PackageId")
                        .IsUnique();

                    b.ToTable("PackageInfo");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.TicketComment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentCreatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateofCreation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TicketID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TicketID");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Package.Package", b =>
                {
                    b.HasOne("HelpDesk_Menagment_Twilo.Models.DataBase.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Package.PackageInfo", b =>
                {
                    b.HasOne("HelpDesk_Menagment_Twilo.Models.DataBase.Package.Package", "Package")
                        .WithOne("PackageInfo")
                        .HasForeignKey("HelpDesk_Menagment_Twilo.Models.DataBase.Package.PackageInfo", "PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
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

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Package.Package", b =>
                {
                    b.Navigation("PackageInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("HelpDesk_Menagment_Twilo.Models.DataBase.Ticket.Ticket", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
