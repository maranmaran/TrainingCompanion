using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class UnassignUserFromProgramConfigChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingProgramId",
                table: "Trainings",
                column: "TrainingProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingPrograms_TrainingProgramId",
                table: "Trainings",
                column: "TrainingProgramId",
                principalTable: "TrainingPrograms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingPrograms_TrainingProgramId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingProgramId",
                table: "Trainings");

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
