using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class RealDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImage", "ReleaseYear", "Title" },
                values: new object[] { "https://link-naar-coverfoto/queen-anato.jpg", 1975, "A Night at the Opera" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CoverImage", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 2, "https://link-naar-coverfoto/ed-sheeran-divide.jpg", 2017, "÷ (Divide)" },
                    { 3, "https://link-naar-coverfoto/michael-jackson-thriller.jpg", 1982, "Thriller" },
                    { 4, "https://link-naar-coverfoto/john-lennon-imagine.jpg", 1971, "Imagine" },
                    { 5, "https://link-naar-coverfoto/nirvana-nevermind.jpg", 1991, "Nevermind" },
                    { 6, "https://link-naar-coverfoto/the-cure-three-imaginary-boys.jpg", 1979, "Three Imaginary Boys" },
                    { 7, "https://link-naar-coverfoto/oasis-morning-glory.jpg", 1995, "(What's the Story) Morning Glory?" },
                    { 8, "https://link-naar-coverfoto/leonard-cohen-various-positions.jpg", 1984, "Various Positions" },
                    { 9, "https://link-naar-coverfoto/the-beatles-white-album.jpg", 1968, "The Beatles (White Album)" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Artist", "DurationInSeconds", "ReleaseDate", "Title" },
                values: new object[] { "Queen", 354, new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohemian Rhapsody" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "DurationInSeconds", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 2, "Ed Sheeran", 233, "Pop", new DateTime(2017, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shape of You" },
                    { 3, "Michael Jackson", 294, "Pop", new DateTime(1983, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billie Jean" },
                    { 4, "John Lennon", 185, "Soft rock", new DateTime(1971, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imagine" },
                    { 5, "Nirvana", 302, "Grunge", new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smells Like Teen Spirit" },
                    { 6, "The Cure", 174, "Post-punk", new DateTime(1979, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boys Don't Cry" },
                    { 7, "Oasis", 258, "Britpop", new DateTime(1995, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wonderwall" },
                    { 8, "Leonard Cohen", 272, "Folk", new DateTime(1984, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hallelujah" },
                    { 9, "The Beatles", 431, "Pop", new DateTime(1968, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hey Jude" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImage", "ReleaseYear", "Title" },
                values: new object[] { "image", 1997, "testingg" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Artist", "DurationInSeconds", "ReleaseDate", "Title" },
                values: new object[] { "Hello", 234, new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testname" });
        }
    }
}
