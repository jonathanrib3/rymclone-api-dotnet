using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RymCloneApi.src.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniquenessToUserNameAndReviewUserIdAlbumId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id_album_id",
                table: "Reviews",
                columns: new[] { "user_id", "album_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_user_id_album_id",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews",
                column: "user_id");
        }
    }
}
