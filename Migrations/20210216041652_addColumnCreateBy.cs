using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class addColumnCreateBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("c5c5c97d-9e08-4347-b576-b3914de44f76"), "user" },
                    { new Guid("a201d1ba-e163-4d98-8f92-d813c76f538c"), "Manager" },
                    { new Guid("8a59df86-7e82-4f8d-8b30-1fa439625d4a"), "Admin" },
                    { new Guid("b9ee96e5-6452-4508-8266-18861ea0696e"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_CreatedById",
                table: "ProductGroup",
                column: "CreatedById");

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

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_CreatedById",
                table: "ProductGroup");

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
                    { new Guid("62ea7690-504f-4a77-8423-29610a0eed63"), "user" },
                    { new Guid("e73638f7-1440-41bd-840f-661c38cfc8ce"), "Manager" },
                    { new Guid("67b3d8fe-8d45-4cd1-8a86-625426329a08"), "Admin" },
                    { new Guid("aee617a8-6e50-451e-96c9-a094fae012fc"), "Developer" }
                });
        }
    }
}
