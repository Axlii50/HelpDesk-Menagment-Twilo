using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketComment",
                columns: table => new
                {
                    TicketCommentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofCreation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComment", x => x.TicketCommentID);
                    table.ForeignKey(
                        name: "FK_TicketComment_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketComment_TicketID",
                table: "TicketComment",
                column: "TicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketComment");
        }
    }
}
