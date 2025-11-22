using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "termekek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(30)", nullable: false),
                    Leiras = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ar = table.Column<int>(type: "int", nullable: false),
                    Kategoria_Id = table.Column<int>(type: "int", nullable: false),
                    Kep_Url = table.Column<string>(type: "varchar(100)", nullable: false),
                    RegIdo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModIdo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termekek", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "termekek");
        }
    }
}
