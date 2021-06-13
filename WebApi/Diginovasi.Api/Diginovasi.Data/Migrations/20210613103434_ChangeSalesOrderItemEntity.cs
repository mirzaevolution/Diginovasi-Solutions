using Microsoft.EntityFrameworkCore.Migrations;

namespace Diginovasi.Data.Migrations
{
    public partial class ChangeSalesOrderItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodeMaterial",
                table: "SalesOrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodeMaterial",
                table: "SalesOrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
