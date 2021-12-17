using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingRoomIdToSerializedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SerializedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RoomCategoryTypeId" },
                values: new object[] { "Prostorija nije određena", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Učionica A23" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "KancelarijaA" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Učionica Mihajlo Pupin" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BranchId", "Name", "RoomCategoryTypeId" },
                values: new object[] { 2, "KancelarijaB", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Magacin-ITAkademija" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BranchId", "Name", "RoomCategoryTypeId" },
                values: new object[] { 7, 2, "Magacin-ITS", 1 });

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_SerializedItems_RoomId",
                table: "SerializedItems",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedItems_Rooms_RoomId",
                table: "SerializedItems",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerializedItems_Rooms_RoomId",
                table: "SerializedItems");

            migrationBuilder.DropIndex(
                name: "IX_SerializedItems_RoomId",
                table: "SerializedItems");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SerializedItems");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RoomCategoryTypeId" },
                values: new object[] { "Učionica A23", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "KancelarijaA" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Učionica Mihajlo Pupin" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "KancelarijaB" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BranchId", "Name", "RoomCategoryTypeId" },
                values: new object[] { 1, "Magacin-ITAkademija", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "Magacin-ITS" });
        }
    }
}
