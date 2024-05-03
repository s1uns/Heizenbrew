using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsBrewingFieldFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBrewing",
                table: "BrewingEquipment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "BrewingLogs",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Brewers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsBrewing",
                table: "BrewerBrewingEquipment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBrewing",
                table: "BrewerBrewingEquipment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "BrewingLogs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsBrewing",
                table: "BrewingEquipment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Brewers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b6fe62a-36c6-4372-9db6-ae8609fe2d91", "AQAAAAIAAYagAAAAEFu5umnQhxrsZ1CUG8vtr++BL2SLalNiG8pIQFRvpAonuFJn66GSnk46V8rE3ntUMA==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 12, 10, 57, 19, DateTimeKind.Utc).AddTicks(4618));
        }
    }
}
