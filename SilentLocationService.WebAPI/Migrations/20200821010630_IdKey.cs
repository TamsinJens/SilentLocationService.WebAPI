using Microsoft.EntityFrameworkCore.Migrations;

namespace SilentLocationService.WebAPI.Migrations
{
    public partial class IdKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    coordinates = table.Column<string>(nullable: true),
                    backgroundColor = table.Column<string>(nullable: true),
                    silent = table.Column<bool>(nullable: false),
                    vibrate = table.Column<bool>(nullable: false),
                    bluetoothOff = table.Column<bool>(nullable: false),
                    turnedOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "id", "backgroundColor", "bluetoothOff", "coordinates", "description", "name", "silent", "turnedOn", "vibrate" },
                values: new object[] { 1, null, false, null, null, null, false, false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
