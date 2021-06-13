using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diginovasi.Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoCustomer = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Nama = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    NoKontak = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Satuan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satuan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoSalesOrder = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    UrlGambar = table.Column<string>(unicode: false, nullable: true),
                    SatuanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Satuan_SatuanId",
                        column: x => x.SatuanId,
                        principalTable: "Satuan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeMaterial = table.Column<string>(nullable: true),
                    Jumlah = table.Column<int>(nullable: false),
                    SalesId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_SalesOrder_SalesId",
                        column: x => x.SalesId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_SatuanId",
                table: "Material",
                column: "SatuanId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_MaterialId",
                table: "SalesOrderItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesId",
                table: "SalesOrderItems",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderItems");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Satuan");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
