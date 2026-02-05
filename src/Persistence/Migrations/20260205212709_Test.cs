using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RymCloneApi.src.Persistence.Migrations
{
  /// <inheritdoc />
  public partial class Test : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Artists",
        columns: table => new
        {
          Id = table
            .Column<int>(type: "integer", nullable: false)
            .Annotation(
              "Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
            ),
          Name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Artists", x => x.Id);
        }
      );

      migrationBuilder.CreateTable(
        name: "Genres",
        columns: table => new
        {
          Id = table
            .Column<int>(type: "integer", nullable: false)
            .Annotation(
              "Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
            ),
          Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Genres", x => x.Id);
        }
      );

      migrationBuilder.CreateTable(
        name: "Albums",
        columns: table => new
        {
          Id = table
            .Column<int>(type: "integer", nullable: false)
            .Annotation(
              "Npgsql:ValueGenerationStrategy",
              NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
            ),
          Title = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
          ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
          ArtistId = table.Column<int>(type: "integer", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Albums", x => x.Id);
          table.ForeignKey(
            name: "FK_Albums_Artists_ArtistId",
            column: x => x.ArtistId,
            principalTable: "Artists",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "AlbumGenre",
        columns: table => new
        {
          AlbumsId = table.Column<int>(type: "integer", nullable: false),
          GenresId = table.Column<int>(type: "integer", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AlbumGenre", x => new { x.AlbumsId, x.GenresId });
          table.ForeignKey(
            name: "FK_AlbumGenre_Albums_AlbumsId",
            column: x => x.AlbumsId,
            principalTable: "Albums",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
          table.ForeignKey(
            name: "FK_AlbumGenre_Genres_GenresId",
            column: x => x.GenresId,
            principalTable: "Genres",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateIndex(
        name: "IX_AlbumGenre_GenresId",
        table: "AlbumGenre",
        column: "GenresId"
      );

      migrationBuilder.CreateIndex(name: "IX_Albums_ArtistId", table: "Albums", column: "ArtistId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "AlbumGenre");

      migrationBuilder.DropTable(name: "Albums");

      migrationBuilder.DropTable(name: "Genres");

      migrationBuilder.DropTable(name: "Artists");
    }
  }
}
