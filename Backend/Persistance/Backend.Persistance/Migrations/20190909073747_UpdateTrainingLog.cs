using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class UpdateTrainingLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainingId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainingId",
                table: "Exercises",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
