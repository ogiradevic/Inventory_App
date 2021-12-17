using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AmendingSerializedItemsRoomsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputDate",
                table: "ItemsRooms");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Departman nije definisan");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Računovodstvo");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Nastava" });

            migrationBuilder.UpdateData(
                table: "ItemUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Korisnik nije određen", "Korisnik nije određen" });

            migrationBuilder.UpdateData(
                table: "ItemUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartmentId", "LastName", "Name" },
                values: new object[] { 1, "Peric", "Pera" });

            migrationBuilder.InsertData(
                table: "ItemUsers",
                columns: new[] { "Id", "DepartmentId", "LastName", "Name" },
                values: new object[] { 3, 2, "Miric", "Mira" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "ItemTypeId", "Model", "Name" },
                values: new object[] { 1, 1, "Benq55", "Monitor" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "ItemTypeId", "Model", "Name" },
                values: new object[] { 3, 50, 2, "CabronFiber", "Podloga Za Miša" });

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SerialNumber",
                value: "XX-Benq-55");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "InputDate",
                table: "ItemsRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Računovodstvo");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Nastava");

            migrationBuilder.UpdateData(
                table: "ItemUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Peric", "Pera" });

            migrationBuilder.UpdateData(
                table: "ItemUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartmentId", "LastName", "Name" },
                values: new object[] { 2, "Miric", "Mira" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "ItemTypeId", "Model", "Name" },
                values: new object[] { 50, 2, "CabronFiber", "Podloga Za Miša" });

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SerialNumber",
                value: "XX-Acer-55");
        }
    }
}
