using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class BrewingCreatedAtField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Brewings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Brewings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1d58b88-3f41-4e87-b84b-0e934c0dabf0", "AQAAAAIAAYagAAAAEIwlHZm/nUJg0xEcJveAcIvwVWLF0H2zsDx0uCBZ9NZEPxu7V2tp3retY6S8DA2Gew==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 13, 22, 39, 364, DateTimeKind.Utc).AddTicks(7422));
        }
    }
}
