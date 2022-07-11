using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_project.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "456b89e2-83c4-4331-882f-37507d903928", "90784d46-d14d-4c77-922e-fa2b808ae52c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "defcad55-24ed-4ac5-9a05-6f46fdd9ddda", "264bd590-4889-47e4-b141-7a57e6232fa1" });
        }
    }
}
