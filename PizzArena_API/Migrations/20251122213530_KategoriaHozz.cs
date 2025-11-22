using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class KategoriaHozz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriak", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_termekek_Kategoria_Id",
                table: "termekek",
                column: "Kategoria_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_termekek_kategoriak_Kategoria_Id",
                table: "termekek",
                column: "Kategoria_Id",
                principalTable: "kategoriak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_termekek_kategoriak_Kategoria_Id",
                table: "termekek");

            migrationBuilder.DropTable(
                name: "kategoriak");

            migrationBuilder.DropIndex(
                name: "IX_termekek_Kategoria_Id",
                table: "termekek");
        }
    }
}
