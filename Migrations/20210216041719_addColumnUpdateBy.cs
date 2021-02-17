using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class addColumnUpdateBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a59df86-7e82-4f8d-8b30-1fa439625d4a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a201d1ba-e163-4d98-8f92-d813c76f538c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b9ee96e5-6452-4508-8266-18861ea0696e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c97d-9e08-4347-b576-b3914de44f76"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4e4eea53-52cd-4954-9de7-0f2dcc3d9ef9"), "user" },
                    { new Guid("06e2f43d-c972-4977-8115-ecb420d1600f"), "Manager" },
                    { new Guid("52eddab9-1032-469a-b883-2ae4aa81c7a7"), "Admin" },
                    { new Guid("2e1a762b-dc9e-4f9e-8194-f8edb3de892e"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_UpdatedById",
                table: "ProductGroup",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_User_UpdatedById",
                table: "ProductGroup",
                column: "UpdatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_User_UpdatedById",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_UpdatedById",
                table: "ProductGroup");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("06e2f43d-c972-4977-8115-ecb420d1600f"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2e1a762b-dc9e-4f9e-8194-f8edb3de892e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4e4eea53-52cd-4954-9de7-0f2dcc3d9ef9"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("52eddab9-1032-469a-b883-2ae4aa81c7a7"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c5c5c97d-9e08-4347-b576-b3914de44f76"), "user" },
                    { new Guid("a201d1ba-e163-4d98-8f92-d813c76f538c"), "Manager" },
                    { new Guid("8a59df86-7e82-4f8d-8b30-1fa439625d4a"), "Admin" },
                    { new Guid("b9ee96e5-6452-4508-8266-18861ea0696e"), "Developer" }
                });
        }
    }
}
