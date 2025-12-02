using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzArena_API.Migrations
{
    /// <inheritdoc />
    public partial class Guidok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Foreign key törlése
            migrationBuilder.DropForeignKey(
                name: "FK_Fiokok_Szerepkorok_SzerepkorId",
                table: "Fiokok");

            // 2. Szerepkor.Id módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Szerepkorok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            // 3. Fiok.SzerepkorId módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "SzerepkorId",
                table: "Fiokok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // 4. Fiok.Id módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Fiokok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            // 5. Foreign key visszaállítása
            migrationBuilder.AddForeignKey(
                name: "FK_Fiokok_Szerepkorok_SzerepkorId",
                table: "Fiokok",
                column: "SzerepkorId",
                principalTable: "Szerepkorok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Foreign key törlése
            migrationBuilder.DropForeignKey(
                name: "FK_Fiokok_Szerepkorok_SzerepkorId",
                table: "Fiokok");

            // 2. Szerepkor.Id módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Szerepkorok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            // 3. Fiok.SzerepkorId módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "SzerepkorId",
                table: "Fiokok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // 4. Fiok.Id módosítása GUID char(36)-ra
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Fiokok",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            // 5. Foreign key visszaállítása
            migrationBuilder.AddForeignKey(
                name: "FK_Fiokok_Szerepkorok_SzerepkorId",
                table: "Fiokok",
                column: "SzerepkorId",
                principalTable: "Szerepkorok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
