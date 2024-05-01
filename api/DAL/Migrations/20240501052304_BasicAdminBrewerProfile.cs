using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasicAdminBrewerProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54f91b27-4642-4306-a1fd-db14e1054352", "AQAAAAIAAYagAAAAEOb0RJ1HiUxBB11PxG7wiyCR2ae1ETw0ONumUEtzwOjpqefh6RHaU+43KsJa7UaRiQ==" });

            migrationBuilder.InsertData(
                table: "Brewers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "ProfileColor" },
                values: new object[] { new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"), new DateTime(2024, 5, 1, 5, 23, 3, 979, DateTimeKind.Utc).AddTicks(7764), "", "Admin", "Admin", "#000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28dbc160-1c42-4372-8e54-bc7f31031cac", "AQAAAAIAAYagAAAAEPldZWUn/XNoKbj9jRT3+2Ld8A/0eRgOPaluDJjbmQVQazkSnil5Iz3I1I9Ln3OxTg==" });
        }
    }
}
