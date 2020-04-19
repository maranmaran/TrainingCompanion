using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class TrainingBlockDayChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_ApplicationUserId",
                table: "Trainings");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingBlockDays",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_ApplicationUserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingBlockDays");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Trainings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
