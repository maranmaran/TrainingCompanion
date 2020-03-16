using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class AuditUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Audits");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryKey",
                table: "Audits",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Audits",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Audits_PrimaryKey",
                table: "Audits",
                column: "PrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_UserId",
                table: "Audits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Audits_PrimaryKey",
                table: "Audits");

            migrationBuilder.DropIndex(
                name: "IX_Audits_UserId",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Audits");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryKey",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
