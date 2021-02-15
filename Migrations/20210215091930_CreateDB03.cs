using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class CreateDB03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_CreatedById",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_User_CreatedById",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_CreatedById",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_Product_CreatedById",
                table: "Product");

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

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AmountBefore = table.Column<int>(nullable: false),
                    AmountEdit = table.Column<int>(nullable: false),
                    AmountAfter = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62ea7690-504f-4a77-8423-29610a0eed63"), "user" },
                    { new Guid("e73638f7-1440-41bd-840f-661c38cfc8ce"), "Manager" },
                    { new Guid("67b3d8fe-8d45-4cd1-8a86-625426329a08"), "Admin" },
                    { new Guid("aee617a8-6e50-451e-96c9-a094fae012fc"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("62ea7690-504f-4a77-8423-29610a0eed63"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("67b3d8fe-8d45-4cd1-8a86-625426329a08"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("aee617a8-6e50-451e-96c9-a094fae012fc"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e73638f7-1440-41bd-840f-661c38cfc8ce"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreatedById",
                table: "Product",
                column: "CreatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_User_CreatedById",
                table: "ProductGroup",
                column: "CreatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
