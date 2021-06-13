using Microsoft.EntityFrameworkCore.Migrations;

namespace Diginovasi.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Material");

            migrationBuilder.AddColumn<decimal>(
                name: "Harga",
                table: "Material",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Harga",
                table: "Material");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Material",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
