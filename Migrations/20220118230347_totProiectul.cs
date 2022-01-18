using Microsoft.EntityFrameworkCore.Migrations;

namespace Waxy.Migrations
{
    public partial class totProiectul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Creator_CreatorId",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creator",
                table: "Creator");

            migrationBuilder.RenameTable(
                name: "Creator",
                newName: "Creators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creators",
                table: "Creators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Creators_CreatorId",
                table: "Labels",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Creators_CreatorId",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creators",
                table: "Creators");

            migrationBuilder.RenameTable(
                name: "Creators",
                newName: "Creator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creator",
                table: "Creator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Creator_CreatorId",
                table: "Labels",
                column: "CreatorId",
                principalTable: "Creator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
