using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebiograf.Web.API.Migrations
{
    public partial class productAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Snacks");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Snacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Snacks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Snacks",
                type: "nvarchar(62)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Snacks",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
