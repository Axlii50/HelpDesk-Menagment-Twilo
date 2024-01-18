using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class PackageRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageInfo_Packages_PackageId",
                table: "PackageInfo");

            migrationBuilder.DropIndex(
                name: "IX_PackageInfo_PackageId",
                table: "PackageInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PackageId",
                table: "PackageInfo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PackageInfo_PackageId",
                table: "PackageInfo",
                column: "PackageId",
                unique: true,
                filter: "[PackageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageInfo_Packages_PackageId",
                table: "PackageInfo",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageInfo_Packages_PackageId",
                table: "PackageInfo");

            migrationBuilder.DropIndex(
                name: "IX_PackageInfo_PackageId",
                table: "PackageInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PackageId",
                table: "PackageInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageInfo_PackageId",
                table: "PackageInfo",
                column: "PackageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageInfo_Packages_PackageId",
                table: "PackageInfo",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
