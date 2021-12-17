using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_Inventory.Data.Migrations
{
    public partial class AddingRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoryTypeId",
                table: "Rooms",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomCategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategoryTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoomCategoryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Magacinska prostorija" },
                    { 2, "Radni prostor" }
                });

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Na lokaciji");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Na popravci");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rashodovan");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomCategoryTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomCategoryTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomCategoryTypeId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BranchId", "Name", "RoomCategoryTypeId" },
                values: new object[,]
                {
                    { 5, 1, "Magacin-ITAkademija", 1 },
                    { 6, 2, "Magacin-ITS", 1 },
                    { 4, 2, "KancelarijaB", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryTypeId",
                table: "Rooms",
                column: "RoomCategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategoryTypes_RoomCategoryTypeId",
                table: "Rooms",
                column: "RoomCategoryTypeId",
                principalTable: "RoomCategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategoryTypes_RoomCategoryTypeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomCategoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCategoryTypeId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "RoomCategoryTypeId",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "U magacinu");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Na lokaciji");

            migrationBuilder.UpdateData(
                table: "SerializedItemConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Na popravci");

            migrationBuilder.InsertData(
                table: "SerializedItemConditions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Rashodovan" });
        }
    }
}
