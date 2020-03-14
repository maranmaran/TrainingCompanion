using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class LogLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "SystemExceptions");

            migrationBuilder.AddColumn<string>(
                name: "LogLevel",
                table: "SystemExceptions",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Rpe",
                table: "Sets",
                nullable: false,
                defaultValue: 8.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Rir",
                table: "Sets",
                nullable: false,
                defaultValue: 2.0,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogLevel",
                table: "SystemExceptions");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "SystemExceptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Rpe",
                table: "Sets",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 8.0);

            migrationBuilder.AlterColumn<double>(
                name: "Rir",
                table: "Sets",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 2.0);
        }
    }
}
