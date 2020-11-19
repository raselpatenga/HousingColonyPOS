using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class initial_CreateProductAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    SalePrice = table.Column<float>(nullable: false),
                    DealerPrice = table.Column<float>(nullable: false),
                    CostPrice = table.Column<float>(nullable: false),
                    DealerCashPrice = table.Column<float>(nullable: true),
                    DealerDuePrice = table.Column<float>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    OPQty = table.Column<float>(nullable: true),
                    Purchased = table.Column<int>(nullable: true),
                    Sold = table.Column<int>(nullable: true),
                    OnHand = table.Column<int>(nullable: true),
                    isActive = table.Column<int>(nullable: false),
                    isRow = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
