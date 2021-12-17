using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingRoomFromCompleteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NonSerializedItemRooms_RoomFromId",
                table: "NonSerializedItemRooms",
                column: "RoomFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_NonSerializedItemRooms_Rooms_RoomFromId",
                table: "NonSerializedItemRooms",
                column: "RoomFromId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonSerializedItemRooms_Rooms_RoomFromId",
                table: "NonSerializedItemRooms");

            migrationBuilder.DropIndex(
                name: "IX_NonSerializedItemRooms_RoomFromId",
                table: "NonSerializedItemRooms");
        }
    }
}
