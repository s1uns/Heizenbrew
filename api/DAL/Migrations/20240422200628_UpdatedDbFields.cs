using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDbFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Brewers");

            migrationBuilder.AddColumn<Guid>(
                name: "BrewerId",
                table: "Recipes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LogTime",
                table: "BrewingLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "BrewingEquipment",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "BrewingEquipment",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "RecipeVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BrewerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPositive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeVotes_Brewers_BrewerId",
                        column: x => x.BrewerId,
                        principalTable: "Brewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeVotes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BrewerId",
                table: "Recipes",
                column: "BrewerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeIngredient_RecipesId",
                table: "RecipeRecipeIngredient",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeVotes_BrewerId",
                table: "RecipeVotes",
                column: "BrewerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeVotes_RecipeId",
                table: "RecipeVotes",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Brewers_BrewerId",
                table: "Recipes",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Brewers_BrewerId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeRecipeIngredient");

            migrationBuilder.DropTable(
                name: "RecipeVotes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_BrewerId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "BrewerId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "LogTime",
                table: "BrewingLogs");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "BrewingEquipment");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "BrewingEquipment",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Brewers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
