using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebiograf.Web.API.Migrations
{
    public partial class orderSnack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.CreateTable(
                name: "OrderSnacks",
                columns: table => new
                {
                    SnackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSnacks", x => x.SnackID);
                    table.ForeignKey(
                        name: "FK_OrderSnacks_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSnacks_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSnacks_BookingID",
                table: "OrderSnacks",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSnacks_ProductID",
                table: "OrderSnacks",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSnacks");

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    SnackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.SnackID);
                    table.ForeignKey(
                        name: "FK_Snacks_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Snacks_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_BookingID",
                table: "Snacks",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_ProductID",
                table: "Snacks",
                column: "ProductID");
        }
    }
}
