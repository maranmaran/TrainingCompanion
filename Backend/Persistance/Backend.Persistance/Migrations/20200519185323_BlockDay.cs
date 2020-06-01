using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class BlockDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DurationType",
                table: "TrainingBlocks",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "RestDay",
                table: "TrainingBlockDays",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestDay",
                table: "TrainingBlockDays");

            migrationBuilder.AlterColumn<int>(
                name: "DurationType",
                table: "TrainingBlocks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
