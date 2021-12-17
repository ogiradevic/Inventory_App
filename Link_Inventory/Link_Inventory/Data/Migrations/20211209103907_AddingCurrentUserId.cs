using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingCurrentUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms");

            migrationBuilder.AddColumn<int>(
                name: "ItemUserId",
                table: "SerializedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ItemUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SerializedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ItemUserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_SerializedItems_ItemUserId",
                table: "SerializedItems",
                column: "ItemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms",
                column: "RoomFromId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedItems_ItemUsers_ItemUserId",
                table: "SerializedItems",
                column: "ItemUserId",
                principalTable: "ItemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_SerializedItems_ItemUsers_ItemUserId",
                table: "SerializedItems");

            migrationBuilder.DropIndex(
                name: "IX_SerializedItems_ItemUserId",
                table: "SerializedItems");

            migrationBuilder.DropColumn(
                name: "ItemUserId",
                table: "SerializedItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms",
                column: "RoomFromId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
