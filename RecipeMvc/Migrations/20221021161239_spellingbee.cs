using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeMvc.Migrations
{
    public partial class spellingbee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Measurment",
                table: "RecipeIngredients",
                newName: "Measurement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Measurement",
                table: "RecipeIngredients",
                newName: "Measurment");
        }
    }
}
