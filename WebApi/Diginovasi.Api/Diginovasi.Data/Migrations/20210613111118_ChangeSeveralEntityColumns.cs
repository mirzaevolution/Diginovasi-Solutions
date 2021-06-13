using Microsoft.EntityFrameworkCore.Migrations;

namespace Diginovasi.Data.Migrations
{
    public partial class ChangeSeveralEntityColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_SalesOrder_SalesId",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_SalesId",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "SalesOrderItems");

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderId",
                table: "SalesOrderItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderId",
                table: "SalesOrderItems",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_SalesOrder_SalesOrderId",
                table: "SalesOrderItems",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_SalesOrder_SalesOrderId",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_SalesOrderId",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "SalesOrderItems");

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "SalesOrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesId",
                table: "SalesOrderItems",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_SalesOrder_SalesId",
                table: "SalesOrderItems",
                column: "SalesId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
