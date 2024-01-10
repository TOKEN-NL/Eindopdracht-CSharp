using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class AlbumSeeder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CoverImage", "ReleaseYear", "Title" },
                values: new object[] { 1, "image", 1997, "testingg" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 2, DateTimeKind.Unspecified));
        }
    }
}
