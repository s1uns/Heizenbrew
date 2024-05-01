using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class VotesTableRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeVotes_Brewers_BrewerId",
                table: "RecipeVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeVotes_Recipes_RecipeId",
                table: "RecipeVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeVotes",
                table: "RecipeVotes");

            migrationBuilder.RenameTable(
                name: "RecipeVotes",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeVotes_RecipeId",
                table: "Votes",
                newName: "IX_Votes_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeVotes_BrewerId",
                table: "Votes",
                newName: "IX_Votes_BrewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28dbc160-1c42-4372-8e54-bc7f31031cac", "AQAAAAIAAYagAAAAEPldZWUn/XNoKbj9jRT3+2Ld8A/0eRgOPaluDJjbmQVQazkSnil5Iz3I1I9Ln3OxTg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Brewers_BrewerId",
                table: "Votes",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Recipes_RecipeId",
                table: "Votes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Brewers_BrewerId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Recipes_RecipeId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "RecipeVotes");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_RecipeId",
                table: "RecipeVotes",
                newName: "IX_RecipeVotes_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_BrewerId",
                table: "RecipeVotes",
                newName: "IX_RecipeVotes_BrewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeVotes",
                table: "RecipeVotes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e84050f9-ff3d-4a45-9520-4729a50755a1", "AQAAAAIAAYagAAAAECdJtq1QIEAY73QZnkmFxozB3jT+Z4H6biZxtV7FKY21Fdf7z3kF2sPA4o9yrb5eRg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeVotes_Brewers_BrewerId",
                table: "RecipeVotes",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeVotes_Recipes_RecipeId",
                table: "RecipeVotes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
