using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class MediaFileModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Users_ApplicationUserId",
                table: "MediaFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "MediaFiles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Users_ApplicationUserId",
                table: "MediaFiles",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Users_ApplicationUserId",
                table: "MediaFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "MediaFiles",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Users_ApplicationUserId",
                table: "MediaFiles",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
