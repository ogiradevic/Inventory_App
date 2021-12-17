using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingRoomFromTOSerializedItemsRoomsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomFromId",
                table: "ItemsRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsRooms_RoomFromId",
                table: "ItemsRooms",
                column: "RoomFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms",
                column: "RoomFromId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Rooms_RoomFromId",
                table: "ItemsRooms");

            migrationBuilder.DropIndex(
                name: "IX_ItemsRooms_RoomFromId",
                table: "ItemsRooms");

            migrationBuilder.DropColumn(
                name: "RoomFromId",
                table: "ItemsRooms");
        }
    }
}
