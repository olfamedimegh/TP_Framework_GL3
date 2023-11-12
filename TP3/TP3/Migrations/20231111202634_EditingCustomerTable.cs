using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class EditingCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_custumors_Membershiptypes_MembershiptypeId",
                table: "custumors");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershiptypeId",
                table: "custumors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_custumors_Membershiptypes_MembershiptypeId",
                table: "custumors",
                column: "MembershiptypeId",
                principalTable: "Membershiptypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_custumors_Membershiptypes_MembershiptypeId",
                table: "custumors");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershiptypeId",
                table: "custumors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_custumors_Membershiptypes_MembershiptypeId",
                table: "custumors",
                column: "MembershiptypeId",
                principalTable: "Membershiptypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
