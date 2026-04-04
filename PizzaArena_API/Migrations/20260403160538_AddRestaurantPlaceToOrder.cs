using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaArena_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantPlaceToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_RestaurantId",
                table: "orders",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_restaurants_RestaurantId",
                table: "orders",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_restaurants_RestaurantId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_RestaurantId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "orders");
        }
    }
}
