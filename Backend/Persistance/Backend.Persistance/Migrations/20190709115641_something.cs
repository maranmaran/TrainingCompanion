using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountStatus",
                table: "Users",
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldDefaultValue: "Waiting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountStatus",
                table: "Users",
                nullable: false,
                defaultValue: "Waiting",
                oldClrType: typeof(string),
                oldDefaultValue: "Active");
        }
    }
}
