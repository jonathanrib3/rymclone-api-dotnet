using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RymCloneApi.src.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewTextColumnToReviewAndRenameUserAndReviewTablesToSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId1",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_user_id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_albums_AlbumId1",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_albums_album_id",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "review");

            migrationBuilder.RenameIndex(
                name: "IX_Users_username",
                table: "user",
                newName: "IX_user_username");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId1",
                table: "review",
                newName: "IX_review_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_user_id_album_id",
                table: "review",
                newName: "IX_review_user_id_album_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AlbumId1",
                table: "review",
                newName: "IX_review_AlbumId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_album_id",
                table: "review",
                newName: "IX_review_album_id");

            migrationBuilder.AddColumn<string>(
                name: "review_text",
                table: "review",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_albums_AlbumId1",
                table: "review",
                column: "AlbumId1",
                principalTable: "albums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_albums_album_id",
                table: "review",
                column: "album_id",
                principalTable: "albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_UserId1",
                table: "review",
                column: "UserId1",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_user_id",
                table: "review",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_albums_AlbumId1",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_albums_album_id",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_UserId1",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_user_id",
                table: "review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.DropColumn(
                name: "review_text",
                table: "review");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_user_username",
                table: "Users",
                newName: "IX_Users_username");

            migrationBuilder.RenameIndex(
                name: "IX_review_UserId1",
                table: "Reviews",
                newName: "IX_Reviews_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_review_user_id_album_id",
                table: "Reviews",
                newName: "IX_Reviews_user_id_album_id");

            migrationBuilder.RenameIndex(
                name: "IX_review_AlbumId1",
                table: "Reviews",
                newName: "IX_Reviews_AlbumId1");

            migrationBuilder.RenameIndex(
                name: "IX_review_album_id",
                table: "Reviews",
                newName: "IX_Reviews_album_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId1",
                table: "Reviews",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_user_id",
                table: "Reviews",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_albums_AlbumId1",
                table: "Reviews",
                column: "AlbumId1",
                principalTable: "albums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_albums_album_id",
                table: "Reviews",
                column: "album_id",
                principalTable: "albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
