using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarWars.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCharactersAndFilmsSchemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthYear = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Height = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Homeworld = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mass = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SkinColor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edited = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFilm",
                columns: table => new
                {
                    CharactersId = table.Column<long>(type: "INTEGER", nullable: false),
                    FilmsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFilm", x => new { x.CharactersId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_CharacterFilm_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFilm_FilmsId",
                table: "CharacterFilm",
                column: "FilmsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFilm");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
