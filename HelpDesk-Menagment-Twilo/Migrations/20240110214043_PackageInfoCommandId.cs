using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class PackageInfoCommandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreationCommandID",
                table: "PackageInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationCommandID",
                table: "PackageInfo");
        }
    }
}
