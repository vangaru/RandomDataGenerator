using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomDataGenerator.ConsoleClient.Migrations
{
    /// <inheritdoc />
    public partial class InitialFileEntriesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileEntries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatinString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RussianString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntegerNumber = table.Column<int>(type: "int", nullable: false),
                    FloatingNumber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileEntries");
        }
    }
}
