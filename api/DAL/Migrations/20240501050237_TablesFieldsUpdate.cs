using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TablesFieldsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e84050f9-ff3d-4a45-9520-4729a50755a1", "AQAAAAIAAYagAAAAECdJtq1QIEAY73QZnkmFxozB3jT+Z4H6biZxtV7FKY21Fdf7z3kF2sPA4o9yrb5eRg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76e46b9f-2574-4618-bda5-9520fca55ceb", "AQAAAAIAAYagAAAAEJ9Fc8FCMVSjfeMB/dV9glMfrJYRF50uG9J1Uu8VeeLsbAIsBN2N/C9rUwjjTm70/Q==" });
        }
    }
}
