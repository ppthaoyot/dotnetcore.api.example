using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class addColumnCreateByProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("e48e1981-2c53-4404-90eb-4486a16dc042"), "user" },
                    { new Guid("662dbaa8-b205-471a-84f4-b2593f0598c9"), "Manager" },
                    { new Guid("566c4cdc-73b4-4052-823b-0c5bb4a85374"), "Admin" },
                    { new Guid("2808bf46-ad1c-4995-ad66-a50e22bde1ac"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedById",
                table: "Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedById",
                table: "Product",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreatedById",
                table: "Product",
                column: "CreatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UpdatedById",
                table: "Product",
                column: "UpdatedById",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_CreatedById",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UpdatedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CreatedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedById",
                table: "Product");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2808bf46-ad1c-4995-ad66-a50e22bde1ac"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("566c4cdc-73b4-4052-823b-0c5bb4a85374"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("662dbaa8-b205-471a-84f4-b2593f0598c9"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e48e1981-2c53-4404-90eb-4486a16dc042"));

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
        }
    }
}
