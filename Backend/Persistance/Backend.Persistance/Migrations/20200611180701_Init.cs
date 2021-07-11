using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    EntityType = table.Column<string>(nullable: true),
                    Table = table.Column<string>(nullable: true),
                    PrimaryKey = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Seen = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

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
                name: "SystemLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogLevel = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLog", x => x.Id);
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
                    UsePercentages = table.Column<bool>(nullable: false, defaultValue: false),
                    UseRpeSystem = table.Column<bool>(nullable: false, defaultValue: true),
                    RpeSystem = table.Column<string>(nullable: false, defaultValue: "Rpe"),
                    Language = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "en"),
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
                    JsonParams = table.Column<string>(nullable: true),
                    TrackId = table.Column<Guid>(nullable: false)
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
                name: "Bodyweights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodyweights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bodyweights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Subtype = table.Column<string>(nullable: true),
                    JsonEntity = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    SentAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Read = table.Column<bool>(nullable: false, defaultValue: false),
                    RedirectUrl = table.Column<string>(nullable: true),
                    SystemNotification = table.Column<bool>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: true),
                    SenderAvatar = table.Column<string>(nullable: true),
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
                name: "TrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageFtpFilePath = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Reps = table.Column<double>(nullable: true),
                    DateAchieved = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    SystemCalculated = table.Column<bool>(nullable: false),
                    Bodyweight = table.Column<double>(nullable: true),
                    WilksScore = table.Column<double>(nullable: true),
                    IpfPoints = table.Column<double>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PBs_ExerciseTypes_ExerciseTypeId",
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
                name: "TrainingBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrainingProgramId = table.Column<Guid>(nullable: false),
                    DurationType = table.Column<int>(nullable: false, defaultValue: 0),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBlocks_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    EndedOn = table.Column<DateTime>(nullable: true),
                    TrainingProgramId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgramUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingProgramUsers_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingProgramUsers_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
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
                name: "TrainingBlockDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Modified = table.Column<bool>(nullable: false, defaultValue: false),
                    TrainingBlockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBlockDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                        column: x => x.TrainingBlockId,
                        principalTable: "TrainingBlocks",
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
                    TrainingProgramName = table.Column<string>(nullable: true),
                    TrainingProgramDay = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    TrainingProgramId = table.Column<Guid>(nullable: true),
                    TrainingBlockDayId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                        column: x => x.TrainingBlockDayId,
                        principalTable: "TrainingBlockDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
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
                    Rpe = table.Column<double>(nullable: false, defaultValue: 8.0),
                    Rir = table.Column<double>(nullable: false, defaultValue: 2.0),
                    Reps = table.Column<double>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    MaxUsedForPercentage = table.Column<double>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Power = table.Column<double>(nullable: false),
                    Intensity = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    ProjectedMax = table.Column<double>(nullable: false),
                    AverageVelocity = table.Column<string>(nullable: true),
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
                name: "IX_Audits_PrimaryKey",
                table: "Audits",
                column: "PrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_UserId",
                table: "Audits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodyweights_UserId",
                table: "Bodyweights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ReceiverId",
                table: "ChatMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

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
                name: "IX_ExerciseTypes_ApplicationUserId_Code",
                table: "ExerciseTypes",
                columns: new[] { "ApplicationUserId", "Code" },
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
                name: "IX_PBs_ExerciseTypeId",
                table: "PBs",
                column: "ExerciseTypeId");

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
                name: "IX_TrackItems_TrackId",
                table: "TrackItems",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_DashboardId",
                table: "Tracks",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBlockDays_TrainingBlockId",
                table: "TrainingBlockDays",
                column: "TrainingBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBlocks_TrainingProgramId",
                table: "TrainingBlocks",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_CreatorId",
                table: "TrainingPrograms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramUsers_ApplicationUserId",
                table: "TrainingProgramUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramUsers_TrainingProgramId",
                table: "TrainingProgramUsers",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingProgramId",
                table: "Trainings",
                column: "TrainingProgramId");

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
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Bodyweights");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ExerciseTypeTags");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationSetting");

            migrationBuilder.DropTable(
                name: "PBs");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "SystemLog");

            migrationBuilder.DropTable(
                name: "TrackItems");

            migrationBuilder.DropTable(
                name: "TrainingProgramUsers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "TagGroups");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "TrainingBlockDays");

            migrationBuilder.DropTable(
                name: "TrainingBlocks");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Dashboards");
        }
    }
}