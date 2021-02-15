using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class CreateDB02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductGroup");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductGroup",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "ProductGroup",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
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
                    { new Guid("978cc9e5-0f2f-48f0-81b1-9df51f534e0b"), "user" },
                    { new Guid("89e80607-cb0d-44d2-b417-c00feed1402b"), "Manager" },
                    { new Guid("ed59052c-cb6a-4d14-a084-3f53eef023e9"), "Admin" },
                    { new Guid("4c09c358-13b0-482e-9b22-998c55fcc2d4"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_CreatedById",
                table: "ProductGroup",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedById",
                table: "Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                table: "Product",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_User_CreatedById",
                table: "ProductGroup",
                column: "CreatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_User_CreatedById",
                table: "ProductGroup");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_CreatedById",
                table: "ProductGroup");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4c09c358-13b0-482e-9b22-998c55fcc2d4"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("89e80607-cb0d-44d2-b417-c00feed1402b"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("978cc9e5-0f2f-48f0-81b1-9df51f534e0b"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ed59052c-cb6a-4d14-a084-3f53eef023e9"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ProductGroup");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ProductGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
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
    }
}
