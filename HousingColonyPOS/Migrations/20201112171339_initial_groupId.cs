using Microsoft.EntityFrameworkCore.Migrations;

namespace HousingColonyPOS.Migrations
{
    public partial class initial_groupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GroupName",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
