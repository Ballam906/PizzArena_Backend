using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class TablakKesz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rendelesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(100)", nullable: false),
                    VasarloTelszam = table.Column<string>(type: "varchar(100)", nullable: false),
                    Felhasznalo_Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RendIdo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendelesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rendelesek_Fiokok_Felhasznalo_Id",
                        column: x => x.Felhasznalo_Id,
                        principalTable: "Fiokok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rendeles_Termek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DbAr = table.Column<int>(type: "int", nullable: false),
                    Darab = table.Column<int>(type: "int", nullable: false),
                    Rendeles_Id = table.Column<int>(type: "int", nullable: false),
                    Termek_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendeles_Termek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rendeles_Termek_Rendelesek_Rendeles_Id",
                        column: x => x.Rendeles_Id,
                        principalTable: "Rendelesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rendeles_Termek_termekek_Termek_Id",
                        column: x => x.Termek_Id,
                        principalTable: "termekek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rendeles_Termek_Rendeles_Id",
                table: "Rendeles_Termek",
                column: "Rendeles_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rendeles_Termek_Termek_Id",
                table: "Rendeles_Termek",
                column: "Termek_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rendelesek_Felhasznalo_Id",
                table: "Rendelesek",
                column: "Felhasznalo_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rendeles_Termek");

            migrationBuilder.DropTable(
                name: "Rendelesek");
        }
    }
}
