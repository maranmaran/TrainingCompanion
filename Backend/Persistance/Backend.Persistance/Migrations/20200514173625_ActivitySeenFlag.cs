using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class ActivitySeenFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Audits",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Audits",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Audits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Audits",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
