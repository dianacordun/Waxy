using Microsoft.EntityFrameworkCore.Migrations;

namespace Waxy.Migrations
{
    public partial class RemoveInstagramfromCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstagramUsername",
                table: "Creator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstagramUsername",
                table: "Creator",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
