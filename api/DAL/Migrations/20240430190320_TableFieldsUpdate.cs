using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TableFieldsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeRecipeIngredient");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipes",
                newName: "Title");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76e46b9f-2574-4618-bda5-9520fca55ceb", "AQAAAAIAAYagAAAAEJ9Fc8FCMVSjfeMB/dV9glMfrJYRF50uG9J1Uu8VeeLsbAIsBN2N/C9rUwjjTm70/Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Recipes",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "RecipeRecipeIngredient",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeIngredient", x => new { x.IngredientsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeIngredient_RecipeIngredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRecipeIngredient_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81a88b9c-e7de-4d90-a872-37efda16d1b3", "AQAAAAIAAYagAAAAEJOR+Qdvw/1unENiUgpHXRe6jmmVidC5z0gnqaeoINnq1Ss+oavWaSP0ShLm8SBocQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeIngredient_RecipesId",
                table: "RecipeRecipeIngredient",
                column: "RecipesId");
        }
    }
}
