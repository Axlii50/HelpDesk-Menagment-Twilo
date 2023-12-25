using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class Packages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageShippingID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateString = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Packages_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_AccountID",
                table: "Packages",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
