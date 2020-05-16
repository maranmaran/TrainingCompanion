using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class TrainingBlockDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInDays",
                table: "TrainingBlocks");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TrainingBlocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationType",
                table: "TrainingBlocks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingBlocks");

            migrationBuilder.DropColumn(
                name: "DurationType",
                table: "TrainingBlocks");

            migrationBuilder.AddColumn<int>(
                name: "DurationInDays",
                table: "TrainingBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
