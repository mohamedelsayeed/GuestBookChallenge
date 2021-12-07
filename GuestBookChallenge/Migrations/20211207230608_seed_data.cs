using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "ProfilePic", "UserName" },
                values: new object[] { 1, "Mohamed", "123456", null, "Mohamed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "ProfilePic", "UserName" },
                values: new object[] { 2, "Mostafa", "123456", null, "Mostafa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "ProfilePic", "UserName" },
                values: new object[] { 3, "Mahmoud", "123456", null, "Mahmoud" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Some random text ", "first", 1 },
                    { 2, "Some random text ", "sec", 1 },
                    { 3, "Some random text ", "third", 1 },
                    { 4, "Some random text ", "first", 2 },
                    { 5, "Some random text ", "sec", 2 },
                    { 6, "Some random text ", "third", 2 },
                    { 7, "Some random text ", "first", 3 },
                    { 8, "Some random text ", "sec", 3 },
                    { 9, "Some random text ", "third", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
