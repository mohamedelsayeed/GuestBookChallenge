using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    public partial class message_reply_pic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Replys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Replys");

            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Messages");
        }
    }
}
