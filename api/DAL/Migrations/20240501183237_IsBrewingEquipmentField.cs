using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsBrewingEquipmentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBrewing",
                table: "BrewingEquipment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60872f17-7942-4b50-86f8-d6e638f0fd78", "AQAAAAIAAYagAAAAED5HhhmHNGLCrXWgvmn99EO2LOMn+DXVvcOwCi+L9Ofu7y/xTfwbno0rDFaubLfF8w==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 18, 32, 37, 446, DateTimeKind.Utc).AddTicks(772));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBrewing",
                table: "BrewingEquipment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cafcd732-5df7-4a99-8db6-01f87ed6eefe", "AQAAAAIAAYagAAAAEAucFIOnnuV8qAFi5pUO/gpmDsqnSRe1lC1c+IWpnzvV12JqrEHWLNkSuZqIaGpV8Q==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 1, 15, 32, 33, 388, DateTimeKind.Utc).AddTicks(7010));
        }
    }
}
