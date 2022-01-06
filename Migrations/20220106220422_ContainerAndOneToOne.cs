using Microsoft.EntityFrameworkCore.Migrations;

namespace Waxy.Migrations
{
    public partial class ContainerAndOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContainerId",
                table: "Candles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candles_ContainerId",
                table: "Candles",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candles_Containers_ContainerId",
                table: "Candles",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candles_Containers_ContainerId",
                table: "Candles");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Candles_ContainerId",
                table: "Candles");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                table: "Candles");
        }
    }
}
