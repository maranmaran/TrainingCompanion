using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class updatesonproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Show",
                table: "ExerciseTypeExerciseProperty",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "HexColor",
                table: "ExercisePropertyTypes",
                nullable: true,
                defaultValue: "#ffffff");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ExercisePropertyTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HexColor",
                table: "ExercisePropertyTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ExercisePropertyTypes");

            migrationBuilder.AlterColumn<bool>(
                name: "Show",
                table: "ExerciseTypeExerciseProperty",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
