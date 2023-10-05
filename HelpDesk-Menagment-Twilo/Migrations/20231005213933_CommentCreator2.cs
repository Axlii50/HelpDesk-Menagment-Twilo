using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk_Menagment_Twilo.Migrations
{
    public partial class CommentCreator2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComment_Ticket_TicketID",
                table: "TicketComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketComment",
                table: "TicketComment");

            migrationBuilder.RenameTable(
                name: "TicketComment",
                newName: "TicketComments");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComment_TicketID",
                table: "TicketComments",
                newName: "IX_TicketComments_TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketComments",
                table: "TicketComments",
                column: "TicketCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Ticket_TicketID",
                table: "TicketComments",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Ticket_TicketID",
                table: "TicketComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketComments",
                table: "TicketComments");

            migrationBuilder.RenameTable(
                name: "TicketComments",
                newName: "TicketComment");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_TicketID",
                table: "TicketComment",
                newName: "IX_TicketComment_TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketComment",
                table: "TicketComment",
                column: "TicketCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComment_Ticket_TicketID",
                table: "TicketComment",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID");
        }
    }
}
