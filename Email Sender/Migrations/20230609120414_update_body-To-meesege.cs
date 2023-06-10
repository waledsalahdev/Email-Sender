using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Email_Sender.Migrations
{
    public partial class update_bodyTomeesege : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "MailRequests",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "MailRequests",
                newName: "Body");
        }
    }
}
