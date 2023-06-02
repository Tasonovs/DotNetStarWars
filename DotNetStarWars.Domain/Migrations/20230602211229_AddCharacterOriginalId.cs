using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarWars.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterOriginalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OriginalId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Characters");
        }
    }
}
