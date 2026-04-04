using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaArena_API.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusEsRestaurantContactPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "restaurants",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");
        }
    }
}
