using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class exerciseproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "RpeSystem",
                table: "UserSettings",
                nullable: false,
                defaultValue: "Rpe");

            migrationBuilder.AddColumn<string>(
                name: "UnitSystem",
                table: "UserSettings",
                nullable: false,
                defaultValue: "Metric");

            migrationBuilder.AddColumn<bool>(
                name: "UseRpeSystem",
                table: "UserSettings",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "True");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                table: "MediaFiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BarPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarPositions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grips",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grips_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RangeOfMotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeOfMotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangeOfMotions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stances_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    RequiresReps = table.Column<bool>(nullable: true),
                    RequiresSets = table.Column<bool>(nullable: true),
                    RequiresWeight = table.Column<bool>(nullable: true),
                    RequiresBodyweight = table.Column<bool>(nullable: true),
                    RequiresTime = table.Column<bool>(nullable: true),
                    BarTypeId = table.Column<Guid>(nullable: false),
                    BarPositionId = table.Column<Guid>(nullable: false),
                    StanceId = table.Column<Guid>(nullable: false),
                    GripId = table.Column<Guid>(nullable: false),
                    RangeOfMotionId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    AthleteId = table.Column<Guid>(nullable: false),
                    AdminId = table.Column<Guid>(nullable: true),
                    CoachId = table.Column<Guid>(nullable: true),
                    SoloAthleteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Users_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_BarPositions_BarPositionId",
                        column: x => x.BarPositionId,
                        principalTable: "BarPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_BarTypes_BarTypeId",
                        column: x => x.BarTypeId,
                        principalTable: "BarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_ExerciseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Grips_GripId",
                        column: x => x.GripId,
                        principalTable: "Grips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_RangeOfMotions_RangeOfMotionId",
                        column: x => x.RangeOfMotionId,
                        principalTable: "RangeOfMotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Users_SoloAthleteId",
                        column: x => x.SoloAthleteId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Stances_StanceId",
                        column: x => x.StanceId,
                        principalTable: "Stances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
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
                name: "ExerciseEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMax",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    Max = table.Column<double>(nullable: false),
                    WilksScore = table.Column<double>(nullable: false),
                    IpfPoints = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseMax_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadAccomodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadAccomodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadAccomodations_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadAccomodations_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tempos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tempos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tempos_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tempos_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lift",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Reps = table.Column<double>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Rpe = table.Column<double>(nullable: false),
                    Intensity = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    AverageVelocity = table.Column<string>(nullable: true),
                    ProjectedMax = table.Column<double>(nullable: false),
                    ExerciseId = table.Column<Guid>(nullable: true)
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
                name: "IX_BarPositions_ApplicationUserId",
                table: "BarPositions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BarTypes_ApplicationUserId",
                table: "BarTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TrainingId",
                table: "Exercise",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_ApplicationUserId",
                table: "ExerciseCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipments_ApplicationUserId",
                table: "ExerciseEquipments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipments_ExerciseTypeId",
                table: "ExerciseEquipments",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMax_ExerciseTypeId",
                table: "ExerciseMax",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_AdminId",
                table: "ExerciseTypes",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_AthleteId",
                table: "ExerciseTypes",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_BarPositionId",
                table: "ExerciseTypes",
                column: "BarPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_BarTypeId",
                table: "ExerciseTypes",
                column: "BarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_CategoryId",
                table: "ExerciseTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_CoachId",
                table: "ExerciseTypes",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_GripId",
                table: "ExerciseTypes",
                column: "GripId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_RangeOfMotionId",
                table: "ExerciseTypes",
                column: "RangeOfMotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_SoloAthleteId",
                table: "ExerciseTypes",
                column: "SoloAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_StanceId",
                table: "ExerciseTypes",
                column: "StanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Grips_ApplicationUserId",
                table: "Grips",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lift_ExerciseId",
                table: "Lift",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadAccomodations_ApplicationUserId",
                table: "LoadAccomodations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadAccomodations_ExerciseTypeId",
                table: "LoadAccomodations",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RangeOfMotions_ApplicationUserId",
                table: "RangeOfMotions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stances_ApplicationUserId",
                table: "Stances",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tempos_ApplicationUserId",
                table: "Tempos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tempos_ExerciseTypeId",
                table: "Tempos",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UserId",
                table: "Training",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Training_TrainingId",
                table: "MediaFiles",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Training_TrainingId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "ExerciseEquipments");

            migrationBuilder.DropTable(
                name: "ExerciseMax");

            migrationBuilder.DropTable(
                name: "Lift");

            migrationBuilder.DropTable(
                name: "LoadAccomodations");

            migrationBuilder.DropTable(
                name: "Tempos");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "BarPositions");

            migrationBuilder.DropTable(
                name: "BarTypes");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "Grips");

            migrationBuilder.DropTable(
                name: "RangeOfMotions");

            migrationBuilder.DropTable(
                name: "Stances");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_TrainingId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "RpeSystem",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UnitSystem",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UseRpeSystem",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "MediaFiles");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Users",
                nullable: true,
                defaultValue: "True",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                nullable: true);
        }
    }
}
