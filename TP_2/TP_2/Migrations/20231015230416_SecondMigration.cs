using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_2.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId1",
                table: "movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId1",
                table: "movies",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId1",
                table: "movies",
                column: "GenreId1",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId1",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId1",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "movies");
        }
    }
}
