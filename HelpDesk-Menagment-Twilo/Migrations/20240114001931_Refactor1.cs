using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class Refactor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlatformAccountId",
                table: "PackageInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PackageInfo_PlatformAccountId",
                table: "PackageInfo",
                column: "PlatformAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageInfo_PlatformAccounts_PlatformAccountId",
                table: "PackageInfo",
                column: "PlatformAccountId",
                principalTable: "PlatformAccounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageInfo_PlatformAccounts_PlatformAccountId",
                table: "PackageInfo");

            migrationBuilder.DropIndex(
                name: "IX_PackageInfo_PlatformAccountId",
                table: "PackageInfo");

            migrationBuilder.DropColumn(
                name: "PlatformAccountId",
                table: "PackageInfo");
        }
    }
}
