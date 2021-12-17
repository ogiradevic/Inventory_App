using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingInvoiceItemToSerializedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceItemId",
                table: "SerializedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aktivan");

            migrationBuilder.CreateIndex(
                name: "IX_SerializedItems_InvoiceItemId",
                table: "SerializedItems",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsRooms_ItemUserId",
                table: "ItemsRooms",
                column: "ItemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_ItemUsers_ItemUserId",
                table: "ItemsRooms",
                column: "ItemUserId",
                principalTable: "ItemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedItems_InvoiceItems_InvoiceItemId",
                table: "SerializedItems",
                column: "InvoiceItemId",
                principalTable: "InvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_ItemUsers_ItemUserId",
                table: "ItemsRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_SerializedItems_InvoiceItems_InvoiceItemId",
                table: "SerializedItems");

            migrationBuilder.DropIndex(
                name: "IX_SerializedItems_InvoiceItemId",
                table: "SerializedItems");

            migrationBuilder.DropIndex(
                name: "IX_ItemsRooms_ItemUserId",
                table: "ItemsRooms");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "SerializedItems");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Na lokaciji");

            migrationBuilder.InsertData(
                table: "SerializedItems",
                columns: new[] { "Id", "ItemId", "ItemUserId", "RoomId", "SerialNumber", "SerializedItemConditionId" },
                values: new object[] { 2, 2, 1, 1, "XX-Benq-55", 1 });

            migrationBuilder.InsertData(
                table: "SerializedItems",
                columns: new[] { "Id", "ItemId", "ItemUserId", "RoomId", "SerialNumber", "SerializedItemConditionId" },
                values: new object[] { 1, 1, 1, 1, "XX-Acer-54", 1 });
        }
    }
}
