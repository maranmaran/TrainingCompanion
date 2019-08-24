using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class Hexbackground : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HexColor",
                table: "ExercisePropertyTypes",
                nullable: true,
                defaultValue: "#616161",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "#ffffff");

            migrationBuilder.AddColumn<string>(
                name: "HexBackground",
                table: "ExercisePropertyTypes",
                nullable: true,
                defaultValue: "#fef6f9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HexBackground",
                table: "ExercisePropertyTypes");

            migrationBuilder.AlterColumn<string>(
                name: "HexColor",
                table: "ExercisePropertyTypes",
                nullable: true,
                defaultValue: "#ffffff",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "#616161");
        }
    }
}
