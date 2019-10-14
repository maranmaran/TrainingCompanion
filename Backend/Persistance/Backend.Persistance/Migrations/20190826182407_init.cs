using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemExceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Theme = table.Column<string>(nullable: false, defaultValue: "Light"),
                    UnitSystem = table.Column<string>(nullable: false, defaultValue: "Metric"),
                    UseRpeSystem = table.Column<bool>(nullable: false, defaultValue: true),
                    RpeSystem = table.Column<string>(nullable: false, defaultValue: "Rpe")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false, defaultValue: "Male"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    AccountType = table.Column<string>(nullable: false),
                    TrialDuration = table.Column<int>(nullable: false, defaultValue: 15),
                    UserSettingsId = table.Column<Guid>(nullable: true),
                    CoachId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_UserSettingsId",
                        column: x => x.UserSettingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SentAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    SeenAt = table.Column<DateTime>(nullable: true),
                    ContainsMedia = table.Column<bool>(nullable: false),
                    DownloadUrl = table.Column<string>(nullable: true),
                    FileSizeInBytes = table.Column<int>(nullable: true),
                    S3Filename = table.Column<string>(nullable: true),
                    SenderId = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Order = table.Column<int>(nullable: false),
                    HexColor = table.Column<string>(nullable: true, defaultValue: "#616161"),
                    HexBackground = table.Column<string>(nullable: true, defaultValue: "#fef6f9"),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagGroups_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
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
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    RequiresReps = table.Column<bool>(nullable: true, defaultValue: true),
                    RequiresSets = table.Column<bool>(nullable: true, defaultValue: true),
                    RequiresWeight = table.Column<bool>(nullable: true, defaultValue: true),
                    RequiresBodyweight = table.Column<bool>(nullable: true, defaultValue: false),
                    RequiresTime = table.Column<bool>(nullable: true, defaultValue: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTrained = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Note = table.Column<string>(nullable: true),
                    NoteRead = table.Column<bool>(nullable: false, defaultValue: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    TagGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_TagGroups_TagGroupId",
                        column: x => x.TagGroupId,
                        principalTable: "TagGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    TrainingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    FtpFilePath = table.Column<string>(nullable: true),
                    DownloadUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    DateUploaded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    TrainingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaFiles_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFiles_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Show = table.Column<bool>(nullable: false, defaultValue: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeExerciseProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeExerciseProperties_ExerciseProperties_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeExerciseProperties_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
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
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMax_ExerciseTypeId",
                table: "ExerciseMax",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_TagGroupId",
                table: "Tags",
                column: "TagGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroups_ApplicationUserId",
                table: "TagGroups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeExerciseProperties_TagId",
                table: "ExerciseTypeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeExerciseProperties_ExerciseTypeId",
                table: "ExerciseTypeTags",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_ApplicationUserId",
                table: "ExerciseTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ApplicationUserId",
                table: "MediaFiles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_TrainingId",
                table: "MediaFiles",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingsId",
                table: "Users",
                column: "UserSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CoachId",
                table: "Users",
                column: "CoachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ExerciseMax");

            migrationBuilder.DropTable(
                name: "ExerciseTypeTags");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "SystemExceptions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TagGroups");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
