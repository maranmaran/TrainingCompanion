using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserSettingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

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
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DashboardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Theme = table.Column<string>(nullable: false, defaultValue: "Light"),
                    UnitSystem = table.Column<string>(nullable: false, defaultValue: "Metric"),
                    UseRpeSystem = table.Column<bool>(nullable: false, defaultValue: true),
                    RpeSystem = table.Column<string>(nullable: false, defaultValue: "Rpe"),
                    MainDashboardId = table.Column<Guid>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Dashboards_MainDashboardId",
                        column: x => x.MainDashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Component = table.Column<string>(nullable: true),
                    TrackId = table.Column<Guid>(nullable: false),
                    ParamsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackItems_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationType = table.Column<string>(nullable: false),
                    ReceiveNotification = table.Column<bool>(nullable: false, defaultValue: true),
                    ReceiveMail = table.Column<bool>(nullable: false, defaultValue: true),
                    UserSettingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSetting_UserSettings_UserSettingId",
                        column: x => x.UserSettingId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserSettingId = table.Column<Guid>(nullable: false),
                    CoachId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_UserSettingId",
                        column: x => x.UserSettingId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackItemParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JsonParams = table.Column<string>(nullable: true),
                    TrackItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackItemParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackItemParams_TrackItems_TrackItemId",
                        column: x => x.TrackItemId,
                        principalTable: "TrackItems",
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
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    RequiresReps = table.Column<bool>(nullable: false, defaultValue: true),
                    RequiresSets = table.Column<bool>(nullable: false, defaultValue: true),
                    RequiresWeight = table.Column<bool>(nullable: false, defaultValue: true),
                    RequiresBodyweight = table.Column<bool>(nullable: false, defaultValue: false),
                    RequiresTime = table.Column<bool>(nullable: false, defaultValue: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Payload = table.Column<string>(nullable: true),
                    SentAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Read = table.Column<bool>(nullable: false, defaultValue: false),
                    RedirectUrl = table.Column<string>(nullable: true),
                    SystemNotification = table.Column<bool>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ExerciseMax",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    DateAchieved = table.Column<DateTime>(nullable: false),
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
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_TagGroups_TagGroupId",
                        column: x => x.TagGroupId,
                        principalTable: "TagGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    TrainingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.PrimaryKey("PK_ExerciseTypeTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeTags_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TrainingId = table.Column<Guid>(nullable: true),
                    ExerciseId = table.Column<Guid>(nullable: true)
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
                        name: "FK_MediaFiles_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaFiles_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ExerciseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ReceiverId",
                table: "ChatMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMax_ExerciseTypeId",
                table: "ExerciseMax",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_ApplicationUserId",
                table: "ExerciseTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_Code",
                table: "ExerciseTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeTags_ExerciseTypeId",
                table: "ExerciseTypeTags",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeTags_TagId",
                table: "ExerciseTypeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ApplicationUserId",
                table: "MediaFiles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ExerciseId",
                table: "MediaFiles",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_TrainingId",
                table: "MediaFiles",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSetting_UserSettingId",
                table: "NotificationSetting",
                column: "UserSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroups_ApplicationUserId",
                table: "TagGroups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagGroupId",
                table: "Tags",
                column: "TagGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackItemParams_TrackItemId",
                table: "TrackItemParams",
                column: "TrackItemId",
                unique: true,
                filter: "[TrackItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_Code",
                table: "TrackItems",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_TrackId",
                table: "TrackItems",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_DashboardId",
                table: "Tracks",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingId",
                table: "Users",
                column: "UserSettingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CoachId",
                table: "Users",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_ApplicationUserId",
                table: "UserSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_MainDashboardId",
                table: "UserSettings",
                column: "MainDashboardId",
                unique: true,
                filter: "[MainDashboardId] IS NOT NULL");
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
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationSetting");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "SystemExceptions");

            migrationBuilder.DropTable(
                name: "TrackItemParams");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrackItems");

            migrationBuilder.DropTable(
                name: "TagGroups");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Dashboards");
        }
    }
}
