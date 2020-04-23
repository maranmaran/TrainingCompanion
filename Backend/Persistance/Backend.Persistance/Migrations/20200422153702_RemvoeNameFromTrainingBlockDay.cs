using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class RemvoeNameFromTrainingBlockDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingBlockDays");

            migrationBuilder.DropColumn(
                name: "RestDay",
                table: "TrainingBlockDays");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TrainingBlockDays",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "TrainingBlockDays");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingBlockDays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RestDay",
                table: "TrainingBlockDays",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
