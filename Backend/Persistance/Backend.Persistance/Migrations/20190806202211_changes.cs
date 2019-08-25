using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                defaultValue: "Coach",
                oldClrType: typeof(string),
                oldDefaultValue: "ApplicationUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                defaultValue: "ApplicationUser",
                oldClrType: typeof(string),
                oldDefaultValue: "Coach");
        }
    }
}
