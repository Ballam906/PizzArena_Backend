using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaArena_API.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantNameToContactEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantName",
                table: "globalSettings",
                newName: "ContactEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "globalSettings",
                newName: "RestaurantName");
        }
    }
}
