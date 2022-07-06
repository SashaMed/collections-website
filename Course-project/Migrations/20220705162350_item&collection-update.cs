using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_project.Migrations
{
    public partial class itemcollectionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LargeDescription1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LargeDescription2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LargeDescription3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BoolExtraField",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DateExtraField",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntExtraField",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "LargeStringExtraField",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringExtraField",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Items",
                newName: "DateCustom3");

            migrationBuilder.RenameColumn(
                name: "NumberOfСopies",
                table: "Items",
                newName: "IntCustom3");

            migrationBuilder.RenameColumn(
                name: "NumberOfPages",
                table: "Items",
                newName: "IntCustom2");

            migrationBuilder.RenameColumn(
                name: "NumberOfChapters",
                table: "Items",
                newName: "IntCustom1");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Items",
                newName: "DateCustom2");

            migrationBuilder.RenameColumn(
                name: "BoolField3",
                table: "Items",
                newName: "BoolCustom3");

            migrationBuilder.RenameColumn(
                name: "BoolField2",
                table: "Items",
                newName: "BoolCustom2");

            migrationBuilder.RenameColumn(
                name: "BoolField1",
                table: "Items",
                newName: "BoolCustom1");

            migrationBuilder.RenameColumn(
                name: "AnotherDate",
                table: "Items",
                newName: "DateCustom1");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LargeDescriptionCustom1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeDescriptionCustom2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeDescriptionCustom3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringCustom1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringCustom2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringCustom3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeStringName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeStringName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LargeStringName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de0a8f9d-b856-409d-bfa7-5f8179d15a9e", "1fc18ba4-cad0-413c-8899-c9d8e30d29e0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeDescriptionCustom1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LargeDescriptionCustom2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LargeDescriptionCustom3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringCustom1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringCustom2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringCustom3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BoolName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "BoolName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "BoolName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DateName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DateName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DateName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "LargeStringName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "LargeStringName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "LargeStringName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringName3",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "IntCustom3",
                table: "Items",
                newName: "NumberOfСopies");

            migrationBuilder.RenameColumn(
                name: "IntCustom2",
                table: "Items",
                newName: "NumberOfPages");

            migrationBuilder.RenameColumn(
                name: "IntCustom1",
                table: "Items",
                newName: "NumberOfChapters");

            migrationBuilder.RenameColumn(
                name: "DateCustom3",
                table: "Items",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "DateCustom2",
                table: "Items",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "DateCustom1",
                table: "Items",
                newName: "AnotherDate");

            migrationBuilder.RenameColumn(
                name: "BoolCustom3",
                table: "Items",
                newName: "BoolField3");

            migrationBuilder.RenameColumn(
                name: "BoolCustom2",
                table: "Items",
                newName: "BoolField2");

            migrationBuilder.RenameColumn(
                name: "BoolCustom1",
                table: "Items",
                newName: "BoolField1");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LargeDescription1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LargeDescription2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LargeDescription3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "BoolExtraField",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DateExtraField",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IntExtraField",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LargeStringExtraField",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StringExtraField",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "sasha",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1b07dcb-d6f8-4981-ab5e-e132177c09fb", "7bceb62c-0ddd-4e08-beba-def0809953df" });
        }
    }
}
