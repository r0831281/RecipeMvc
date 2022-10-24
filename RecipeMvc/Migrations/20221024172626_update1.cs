using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeMvc.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ingredients",
                newName: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "ingredients",
                newName: "Id");
        }
    }
}
