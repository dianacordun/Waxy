using Microsoft.EntityFrameworkCore.Migrations;

namespace Waxy.Migrations
{
    public partial class LabelAndOneToManyLabelCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Containers_ContainerId",
                table: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Label",
                table: "Label");

            migrationBuilder.RenameTable(
                name: "Label",
                newName: "Labels");

            migrationBuilder.RenameIndex(
                name: "IX_Label_ContainerId",
                table: "Labels",
                newName: "IX_Labels_ContainerId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Labels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_CreatorId",
                table: "Labels",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Containers_ContainerId",
                table: "Labels",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Creator_CreatorId",
                table: "Labels",
                column: "CreatorId",
                principalTable: "Creator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Containers_ContainerId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Creator_CreatorId",
                table: "Labels");

            migrationBuilder.DropTable(
                name: "Creator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_CreatorId",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Labels");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Label");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_ContainerId",
                table: "Label",
                newName: "IX_Label_ContainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Label",
                table: "Label",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Containers_ContainerId",
                table: "Label",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
