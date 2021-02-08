using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmileShop.API.Migrations
{
    public partial class authCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("531e713a-f058-4797-94d5-f16285f30502"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("57e0bf9f-4625-4e39-a35a-a29d6bf7c910"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("62bfb6f0-98b7-43ec-a1ec-0db49dbbad03"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f5d39aee-3f36-4436-9aba-ec42628928f1"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("57e0bf9f-4625-4e39-a35a-a29d6bf7c910"), "user" },
                    { new Guid("f5d39aee-3f36-4436-9aba-ec42628928f1"), "Manager" },
                    { new Guid("531e713a-f058-4797-94d5-f16285f30502"), "Admin" },
                    { new Guid("62bfb6f0-98b7-43ec-a1ec-0db49dbbad03"), "Developer" }
                });
        }
    }
}
