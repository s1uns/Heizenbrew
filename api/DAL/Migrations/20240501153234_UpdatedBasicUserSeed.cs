using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBasicUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 32, 33, 388, DateTimeKind.Utc).AddTicks(7010), "illiateliuk@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54f91b27-4642-4306-a1fd-db14e1054352", "AQAAAAIAAYagAAAAEOb0RJ1HiUxBB11PxG7wiyCR2ae1ETw0ONumUEtzwOjpqefh6RHaU+43KsJa7UaRiQ==" });

            migrationBuilder.UpdateData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateTime(2024, 5, 1, 5, 23, 3, 979, DateTimeKind.Utc).AddTicks(7764), "" });
        }
    }
}
