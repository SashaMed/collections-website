using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_project.Migrations
{
    public partial class collections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntExtraField = table.Column<bool>(type: "bit", nullable: false),
                    StringExtraField = table.Column<bool>(type: "bit", nullable: false),
                    BoolExtraField = table.Column<bool>(type: "bit", nullable: false),
                    DateExtraField = table.Column<bool>(type: "bit", nullable: false),
                    LargeStringExtraField = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4dea7fbb-07c0-43ef-890c-ed1429ad2470", "de3811b6-ec52-4fec-b04c-5fd966480ec4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a3003b1e-7e47-40bf-b65c-b905335bcfdb", "3987e1c1-3cc0-49e3-a45c-11d4e027b0d4" });
        }
    }
}
