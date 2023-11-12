using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class addingGenreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"), "GenreFromJsonFile2" },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"), "GenreFromJsonFile1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "Id",
                keyValue: new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"));

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"));
        }
    }
}
