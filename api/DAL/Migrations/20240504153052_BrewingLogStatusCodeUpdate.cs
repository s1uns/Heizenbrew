using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class BrewingLogStatusCodeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrewingLogCode",
                table: "BrewingLogs",
                newName: "StatusCode");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f0fd67f-ee05-4a11-8b5c-4635961fae49", "AQAAAAIAAYagAAAAEO8Wrv6Vl6gHyF9pC1NwR4v2YrIqmq1c9SIXQj9LrwRLxYsWoASZI0Cee0M0v7iYkQ==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 4, 15, 30, 51, 811, DateTimeKind.Utc).AddTicks(4702));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusCode",
                table: "BrewingLogs",
                newName: "BrewingLogCode");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "091fd7ee-c9f4-4967-9b26-5f8ddbc16616", "AQAAAAIAAYagAAAAEE+n38wXElFCf5CsZkfYGDkRwOqtlEYzsdWlxHhqnr0ba/A+6vt+Ren8Qx4Xv+vndA==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 4, 15, 13, 22, 654, DateTimeKind.Utc).AddTicks(4592));
        }
    }
}
