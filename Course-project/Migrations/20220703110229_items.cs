using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_project.Migrations
{
    public partial class items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    NumberOfСopies = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnotherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoolField1 = table.Column<bool>(type: "bit", nullable: false),
                    BoolField2 = table.Column<bool>(type: "bit", nullable: false),
                    BoolField3 = table.Column<bool>(type: "bit", nullable: false),
                    LargeDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1b07dcb-d6f8-4981-ab5e-e132177c09fb", "7bceb62c-0ddd-4e08-beba-def0809953df" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4dea7fbb-07c0-43ef-890c-ed1429ad2470", "de3811b6-ec52-4fec-b04c-5fd966480ec4" });
        }
    }
}
