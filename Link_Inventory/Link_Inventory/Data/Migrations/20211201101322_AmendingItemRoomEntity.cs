using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AmendingItemRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms");

            migrationBuilder.DropIndex(
                name: "IX_ItemsRooms_ItemId",
                table: "ItemsRooms");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemsRooms");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsRooms_SerializedItemId",
                table: "ItemsRooms",
                column: "SerializedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_SerializedItems_SerializedItemId",
                table: "ItemsRooms",
                column: "SerializedItemId",
                principalTable: "SerializedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_SerializedItems_SerializedItemId",
                table: "ItemsRooms");

            migrationBuilder.DropIndex(
                name: "IX_ItemsRooms_SerializedItemId",
                table: "ItemsRooms");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemsRooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsRooms_ItemId",
                table: "ItemsRooms",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
