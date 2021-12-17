using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingAndAmendingItemRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemsRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SerializedItemId",
                table: "ItemsRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms");

            migrationBuilder.DropColumn(
                name: "SerializedItemId",
                table: "ItemsRooms");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemsRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsRooms_Items_ItemId",
                table: "ItemsRooms",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
