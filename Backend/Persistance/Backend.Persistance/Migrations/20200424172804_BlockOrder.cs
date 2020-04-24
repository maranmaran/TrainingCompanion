using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class BlockOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TrainingBlocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_ApplicationUserId_Code",
                table: "ExerciseTypes",
                columns: new[] { "ApplicationUserId", "Code" },
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_ApplicationUserId_Code",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TrainingBlocks");
        }
    }
}
