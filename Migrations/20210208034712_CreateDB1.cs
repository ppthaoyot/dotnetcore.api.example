using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class CreateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2320257c-6c4c-498d-9794-3d967bbeca60"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6dd5781d-ec59-45d8-9583-0b25e3937621"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7a2e69f5-ac0a-4e62-82fd-ded0d472d1e5"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e04636d7-977d-4ba8-aedf-4ece8a1431cb"));

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("058ad2c5-05ba-4b30-9ed2-816b9052de94"), "user" },
                    { new Guid("c4771ada-c7bd-47a2-84de-0e6c76d8eed1"), "Manager" },
                    { new Guid("b3011d94-e5ac-48b2-8d7a-10eb8a2e4df7"), "Admin" },
                    { new Guid("80ba75f8-ebf5-4431-8f69-be2f231646a4"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("058ad2c5-05ba-4b30-9ed2-816b9052de94"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("80ba75f8-ebf5-4431-8f69-be2f231646a4"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b3011d94-e5ac-48b2-8d7a-10eb8a2e4df7"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c4771ada-c7bd-47a2-84de-0e6c76d8eed1"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e04636d7-977d-4ba8-aedf-4ece8a1431cb"), "user" },
                    { new Guid("2320257c-6c4c-498d-9794-3d967bbeca60"), "Manager" },
                    { new Guid("7a2e69f5-ac0a-4e62-82fd-ded0d472d1e5"), "Admin" },
                    { new Guid("6dd5781d-ec59-45d8-9583-0b25e3937621"), "Developer" }
                });
        }
    }
}
