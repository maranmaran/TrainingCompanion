using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class OnDeleteChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                table: "TrainingBlockDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                table: "TrainingBlockDays",
                column: "TrainingBlockId",
                principalTable: "TrainingBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                table: "TrainingBlockDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                table: "TrainingBlockDays",
                column: "TrainingBlockId",
                principalTable: "TrainingBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
