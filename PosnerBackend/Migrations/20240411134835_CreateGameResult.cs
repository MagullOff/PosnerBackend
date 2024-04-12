using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosnerBackend.Migrations
{
    /// <inheritdoc />
    public partial class CreateGameResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClueInformationLevel = table.Column<int>(type: "integer", nullable: false),
                    AverageSpeed = table.Column<double>(type: "double precision", nullable: false),
                    AttemptsJson = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}
