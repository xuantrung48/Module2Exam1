using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddEmailToStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Email",
                value: "xuantrung@email.com");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Email",
                value: "quang@email.com");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Email",
                value: "minh@email.com");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "Email",
                value: "tram@email.com");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Email",
                value: "ghi@email.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");
        }
    }
}
