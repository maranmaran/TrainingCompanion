using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class UnassignUserFromProgramChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingProgramId",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingProgramId",
                table: "Trainings");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
