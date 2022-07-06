using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_project.Migrations
{
    public partial class tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "defcad55-24ed-4ac5-9a05-6f46fdd9ddda", "264bd590-4889-47e4-b141-7a57e6232fa1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagConnections");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de0a8f9d-b856-409d-bfa7-5f8179d15a9e", "1fc18ba4-cad0-413c-8899-c9d8e30d29e0" });
        }
    }
}
