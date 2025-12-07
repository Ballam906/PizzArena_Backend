using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class UjRendelesTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SzallitasiCim",
                table: "Rendelesek",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SzallitasiCim",
                table: "Rendelesek");
        }
    }
}
