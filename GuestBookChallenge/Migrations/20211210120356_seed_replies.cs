using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    public partial class seed_replies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Replys",
                columns: new[] { "Id", "Body", "MessageId", "UserId" },
                values: new object[,]
                {
                    { 1, "Some random reply ", 2, 1 },
                    { 2, "Some random  reply", 2, 1 },
                    { 3, "Some random reply ", 2, 1 },
                    { 4, "Some random reply ", 2, 2 },
                    { 5, "Some random  reply", 2, 2 },
                    { 6, "Some random reply ", 2, 2 },
                    { 7, "Some random reply ", 2, 3 },
                    { 8, "Some random  reply", 2, 3 },
                    { 9, "Some random reply ", 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
