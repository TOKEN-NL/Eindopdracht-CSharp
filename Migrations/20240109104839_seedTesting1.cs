using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class seedTesting1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "DurationInSeconds", "Genre", "ReleaseDate", "Title" },
                values: new object[] { 1, 234, "Rock", new DateTime(1, 1, 1, 0, 0, 0, 2, DateTimeKind.Unspecified), "testname" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
