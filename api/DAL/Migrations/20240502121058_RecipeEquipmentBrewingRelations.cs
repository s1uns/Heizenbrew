using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RecipeEquipmentBrewingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Brewings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Brewings_RecipeId",
                table: "Brewings",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brewings_Recipes_RecipeId",
                table: "Brewings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brewings_Recipes_RecipeId",
                table: "Brewings");

            migrationBuilder.DropIndex(
                name: "IX_Brewings_RecipeId",
                table: "Brewings");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Brewings");

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
    }
}
