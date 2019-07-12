using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class chatmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "ChatMessages");

            migrationBuilder.AddColumn<string>(
                name: "DownloadUrl",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileSizeInBytes",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeenAt",
                table: "ChatMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownloadUrl",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "FileSizeInBytes",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SeenAt",
                table: "ChatMessages");

            migrationBuilder.AddColumn<bool>(
                name: "MediaUrl",
                table: "ChatMessages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "ChatMessages",
                nullable: false,
                defaultValue: false);
        }
    }
}
