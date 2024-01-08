using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class setupDB_try_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Albums_AlbumsAlbumId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsArtistId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_Albums_AlbumsAlbumId",
                table: "AlbumSong");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_Songs_SongsSongId",
                table: "AlbumSong");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artist_ArtistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Songs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SongsSongId",
                table: "AlbumSong",
                newName: "SongsId");

            migrationBuilder.RenameColumn(
                name: "AlbumsAlbumId",
                table: "AlbumSong",
                newName: "AlbumsId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumSong_SongsSongId",
                table: "AlbumSong",
                newName: "IX_AlbumSong_SongsId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Albums",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArtistsArtistId",
                table: "AlbumArtist",
                newName: "ArtistsId");

            migrationBuilder.RenameColumn(
                name: "AlbumsAlbumId",
                table: "AlbumArtist",
                newName: "AlbumsId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumArtist_ArtistsArtistId",
                table: "AlbumArtist",
                newName: "IX_AlbumArtist_ArtistsId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artists",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ArtistName", "FirstName", "LastName" },
                values: new object[] { 1, "testname", "test", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                column: "SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Albums_AlbumsId",
                table: "AlbumArtist",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Artists_ArtistsId",
                table: "AlbumArtist",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_Albums_AlbumsId",
                table: "AlbumSong",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_Songs_SongsId",
                table: "AlbumSong",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Albums_AlbumsId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Artists_ArtistsId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_Albums_AlbumsId",
                table: "AlbumSong");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumSong_Songs_SongsId",
                table: "AlbumSong");

            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Songs",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "SongsId",
                table: "AlbumSong",
                newName: "SongsSongId");

            migrationBuilder.RenameColumn(
                name: "AlbumsId",
                table: "AlbumSong",
                newName: "AlbumsAlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumSong_SongsId",
                table: "AlbumSong",
                newName: "IX_AlbumSong_SongsSongId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Albums",
                newName: "AlbumId");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "AlbumArtist",
                newName: "ArtistsArtistId");

            migrationBuilder.RenameColumn(
                name: "AlbumsId",
                table: "AlbumArtist",
                newName: "AlbumsAlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumArtist_ArtistsId",
                table: "AlbumArtist",
                newName: "IX_AlbumArtist_ArtistsArtistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artist",
                newName: "ArtistId");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Artist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Albums_AlbumsAlbumId",
                table: "AlbumArtist",
                column: "AlbumsAlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsArtistId",
                table: "AlbumArtist",
                column: "ArtistsArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_Albums_AlbumsAlbumId",
                table: "AlbumSong",
                column: "AlbumsAlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumSong_Songs_SongsSongId",
                table: "AlbumSong",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artist_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId");
        }
    }
}
