using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class removeDefaultEnumTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                defaultValue: "Coach",
                oldClrType: typeof(string),
                oldDefaultValue: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                defaultValue: "Admin",
                oldClrType: typeof(string),
                oldDefaultValue: "Coach");
        }
    }
}
