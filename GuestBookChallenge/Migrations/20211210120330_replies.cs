using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    public partial class replies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Replys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replys_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replys_MessageId",
                table: "Replys",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Replys_UserId",
                table: "Replys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replys");
        }
    }
}
