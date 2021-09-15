using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebiograf.Web.API.Migrations
{
    public partial class productAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Snacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_ProductID",
                table: "Snacks",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Snacks_Products_ProductID",
                table: "Snacks",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snacks_Products_ProductID",
                table: "Snacks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Snacks_ProductID",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Snacks");
        }
    }
}
