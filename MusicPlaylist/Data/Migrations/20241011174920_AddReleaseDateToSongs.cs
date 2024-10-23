using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlaylist.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReleaseDateToSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteSongs_Users_UserId1",
                table: "FavoriteSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteSongs",
                table: "FavoriteSongs");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteSongs_UserId1",
                table: "FavoriteSongs");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "FavoriteSongs",
                newName: "FavoriteSongId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavoriteSongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteSongId",
                table: "FavoriteSongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteSongs",
                table: "FavoriteSongs",
                column: "FavoriteSongId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSongs_UserId",
                table: "FavoriteSongs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteSongs_Users_UserId",
                table: "FavoriteSongs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteSongs_Users_UserId",
                table: "FavoriteSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteSongs",
                table: "FavoriteSongs");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteSongs_UserId",
                table: "FavoriteSongs");

            migrationBuilder.RenameColumn(
                name: "FavoriteSongId",
                table: "FavoriteSongs",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavoriteSongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "FavoriteSongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteSongs",
                table: "FavoriteSongs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSongs_UserId1",
                table: "FavoriteSongs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteSongs_Users_UserId1",
                table: "FavoriteSongs",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
