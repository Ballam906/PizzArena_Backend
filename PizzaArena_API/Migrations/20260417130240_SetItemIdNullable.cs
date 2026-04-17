using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaArena_API.Migrations
{
    /// <inheritdoc />
    public partial class SetItemIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_products_Item_Id",
                table: "order_items");

            migrationBuilder.AlterColumn<int>(
                name: "Item_Id",
                table: "order_items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_products_Item_Id",
                table: "order_items",
                column: "Item_Id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_products_Item_Id",
                table: "order_items");

            migrationBuilder.AlterColumn<int>(
                name: "Item_Id",
                table: "order_items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_products_Item_Id",
                table: "order_items",
                column: "Item_Id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
