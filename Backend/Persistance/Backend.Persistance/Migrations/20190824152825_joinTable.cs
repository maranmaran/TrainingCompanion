using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class joinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePropertyTypes_Users_ApplicationUserId",
                table: "ExercisePropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeExerciseProperty_ExerciseProperties_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeExerciseProperty_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Users_AdminId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Users_AthleteId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Users_CoachId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Users_SoloAthleteId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Training_TrainingId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Lift");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_TrainingId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_AdminId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_CoachId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_SoloAthleteId",
                table: "ExerciseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseTypeExerciseProperty",
                table: "ExerciseTypeExerciseProperty");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "SoloAthleteId",
                table: "ExerciseTypes");

            migrationBuilder.RenameTable(
                name: "ExerciseTypeExerciseProperty",
                newName: "ExerciseTypeExerciseProperties");

            migrationBuilder.RenameColumn(
                name: "AthleteId",
                table: "ExerciseTypes",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypes_AthleteId",
                table: "ExerciseTypes",
                newName: "IX_ExerciseTypes_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypeExerciseProperty_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperties",
                newName: "IX_ExerciseTypeExerciseProperties_ExerciseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypeExerciseProperty_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperties",
                newName: "IX_ExerciseTypeExerciseProperties_ExercisePropertyId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ExercisePropertyTypes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseTypeExerciseProperties",
                table: "ExerciseTypeExerciseProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePropertyTypes_Users_ApplicationUserId",
                table: "ExercisePropertyTypes",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeExerciseProperties_ExerciseProperties_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperties",
                column: "ExercisePropertyId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeExerciseProperties_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperties",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Users_ApplicationUserId",
                table: "ExerciseTypes",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePropertyTypes_Users_ApplicationUserId",
                table: "ExercisePropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeExerciseProperties_ExerciseProperties_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeExerciseProperties_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Users_ApplicationUserId",
                table: "ExerciseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseTypeExerciseProperties",
                table: "ExerciseTypeExerciseProperties");

            migrationBuilder.RenameTable(
                name: "ExerciseTypeExerciseProperties",
                newName: "ExerciseTypeExerciseProperty");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ExerciseTypes",
                newName: "AthleteId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypes_ApplicationUserId",
                table: "ExerciseTypes",
                newName: "IX_ExerciseTypes_AthleteId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypeExerciseProperties_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperty",
                newName: "IX_ExerciseTypeExerciseProperty_ExerciseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTypeExerciseProperties_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperty",
                newName: "IX_ExerciseTypeExerciseProperty_ExercisePropertyId");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                table: "MediaFiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "ExerciseTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoachId",
                table: "ExerciseTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoloAthleteId",
                table: "ExerciseTypes",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ExercisePropertyTypes",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseTypeExerciseProperty",
                table: "ExerciseTypeExerciseProperty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTrained = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    NoteRead = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    TrainingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lift",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AverageVelocity = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<Guid>(nullable: true),
                    Intensity = table.Column<string>(nullable: true),
                    ProjectedMax = table.Column<double>(nullable: false),
                    Reps = table.Column<double>(nullable: false),
                    Rpe = table.Column<double>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lift_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_TrainingId",
                table: "MediaFiles",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_AdminId",
                table: "ExerciseTypes",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_CoachId",
                table: "ExerciseTypes",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_SoloAthleteId",
                table: "ExerciseTypes",
                column: "SoloAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TrainingId",
                table: "Exercise",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Lift_ExerciseId",
                table: "Lift",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UserId",
                table: "Training",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePropertyTypes_Users_ApplicationUserId",
                table: "ExercisePropertyTypes",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeExerciseProperty_ExerciseProperties_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperty",
                column: "ExercisePropertyId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeExerciseProperty_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperty",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Users_AdminId",
                table: "ExerciseTypes",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Users_AthleteId",
                table: "ExerciseTypes",
                column: "AthleteId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Users_CoachId",
                table: "ExerciseTypes",
                column: "CoachId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Users_SoloAthleteId",
                table: "ExerciseTypes",
                column: "SoloAthleteId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Training_TrainingId",
                table: "MediaFiles",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
