using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class InterfeszModositasraKesz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ElerhetoE",
                table: "termekek",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElerhetoE",
                table: "termekek");
        }
    }
}
