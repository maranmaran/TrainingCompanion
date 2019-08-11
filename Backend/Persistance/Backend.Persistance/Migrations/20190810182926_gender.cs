using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: false,
                defaultValue: "Male");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                nullable: true);
        }
    }
}
