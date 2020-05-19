using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class BlockDay2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestDay",
                table: "TrainingBlockDays");

            migrationBuilder.AddColumn<bool>(
                name: "Modified",
                table: "TrainingBlockDays",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TrainingBlockDays");

            migrationBuilder.AddColumn<bool>(
                name: "RestDay",
                table: "TrainingBlockDays",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
