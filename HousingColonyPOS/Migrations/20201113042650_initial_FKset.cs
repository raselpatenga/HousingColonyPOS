using Microsoft.EntityFrameworkCore.Migrations;

namespace HousingColonyPOS.Migrations
{
    public partial class initial_FKset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Group_GroupId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GroupId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GroupId1",
                table: "Categories",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Group_GroupId1",
                table: "Categories",
                column: "GroupId1",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Group_GroupId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GroupId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GroupId",
                table: "Categories",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Group_GroupId",
                table: "Categories",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
