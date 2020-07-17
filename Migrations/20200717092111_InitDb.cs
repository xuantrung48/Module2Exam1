using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name" },
                values: new object[] { 1, "C0120" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name" },
                values: new object[] { 2, "C0220" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name" },
                values: new object[] { 3, "C0320" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "Dob", "FullName", "Gender" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trung", 0 },
                    { 2, 1, new DateTime(1991, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quang", 0 },
                    { 3, 1, new DateTime(1992, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minh", 0 },
                    { 4, 2, new DateTime(1993, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trâm", 1 },
                    { 5, 2, new DateTime(1994, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghi", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
