using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class Init : Migration
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
                    RpeSystem = table.Column<string>(nullable: false, defaultValue: "Rpe"),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
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
                    SenderId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id");
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
                    Show = table.Column<bool>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("d56051cb-4751-4a11-b72e-e762e42fc762"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0ea0a473-abca-4d6f-b338-3805d31a96bd"), "TrainingCreated", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("4f334f0f-b588-421c-a312-98b6db1fea58"), "NoteAdded", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("2b5bcc30-8676-436a-b38a-341e6623e1c2"), "MediaAdded", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0c8a5182-ef12-47c6-af9d-381a11ff03ca"), "TrainingCreated", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("6688dbb1-f2fa-4368-b050-9958b4d334d7"), "NoteAdded", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("f863aba1-ec6d-446b-8172-44d6f5b540ab"), "MediaAdded", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("993bff72-f307-42c6-9127-89219b1f251b"), "TrainingCreated", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("d2c7954e-9348-4208-ba1b-87950598f6ab"), "NoteAdded", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("b6178cdb-216b-43bd-a77a-821204668741"), "MediaAdded", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c84ae76a-392f-465d-9076-04cf85f1a436"), "TrainingCreated", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("bbd1f8a0-ba0c-45df-b12f-ee91cf0ff8c0"), "NoteAdded", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c2bbf800-8e8b-43f4-abcc-1fd1dabea2e8"), "MediaAdded", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=B6A0EE&color=ffffff&", new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(1423), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=DC74A0&color=ffffff&", new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(8277), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762"), "coach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=5DD490&color=ffffff&", new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(6715), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2"), "soloathlete" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("5ac43887-533f-4813-8cdc-e3bc061fc091"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0299d6af-89f4-4c54-956b-59aa61796fd7"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("ce3915d8-0e3e-4b04-99b2-34eabc9232bc"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b2cd252d-d2e6-41e7-810a-906a11417d26"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0c6d4916-ca2a-4ba7-9425-533bd8d18569"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("a2400fec-dbfb-4ea2-a205-9b9f7e96b9be"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("c0786318-d7e4-4965-8788-0126104224a0"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=3E2C5B&color=ffffff&", new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(6050), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994"), "athlete", new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c") });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("6baea34a-641e-42c6-a5ea-6402b2d248c5"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("39af0487-69b9-46c6-b2bf-682bff327c33"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("8f518afc-a67c-4a55-9d68-b709707eb949"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab"), 0, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eb90cd28-9fb4-464d-ba20-18c3ee744377"), 0, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("241aa99c-8085-4945-a2da-b37f41c6883f"), 2, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("53c6cacd-f5ba-4c92-a89e-1d7fb63f6cea"), 3, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84fb19ce-7c41-4d32-a150-505d97241d2b"), 4, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1ad02957-7c32-4b24-a8d5-ba08a37ec2d0"), 5, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf43eb14-4de6-4d0a-9ece-6b5fce2331f5"), 6, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f0a711b-4a00-48d3-b6a7-3fc955e0b05a"), 0, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("804bd6d6-3e2b-46e5-a9d1-2637ee367b2a"), 1, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bfed7ea3-8065-4b91-bd95-95a535cccdce"), 2, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("16ffeaf8-b8f4-4a94-b4b2-7735abe3cb79"), 3, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("85143ad1-40f0-41ba-b274-f01a7eaf6c04"), 4, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3074305d-f001-4be2-ad67-90e7dd5669ed"), 1, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d4a491d-d5dd-4bb8-978c-a6338dec0bbe"), 6, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f734fabd-3fb3-4972-8bf5-bf7d15c1e45d"), 5, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8c830a54-4f64-49ca-bd82-a6f0fea60ee2"), 4, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("339481f1-ebbd-437c-b74a-a1dcfd835eef"), 11, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b4611e7-b47d-41f0-8faa-620e1552e75f"), 12, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ee2b6a47-4224-4db9-80d9-65de2f9efee7"), 0, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5ec1d5cc-5520-40cb-aae2-329309746c44"), 1, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c0f5a85-e13a-4e04-a222-7a03e758c457"), 2, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ffd5ed3b-4fbb-47e8-9a7c-61c7d5b1e113"), 3, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ccf0ba0-232e-41a9-acb3-0d3a59bf1879"), 4, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4c1a83b-595d-4bd1-ae69-701a4f202dcf"), 5, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("18e69069-078c-402f-959e-c04f104827ee"), 6, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9d88d02e-917e-4e38-afa9-f6c2b0005ead"), 0, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("37847dc9-7925-4b63-969c-095eb855c4ec"), 1, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9e13388e-7811-48d5-b122-9d514782f99b"), 5, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ead0f417-c5d8-47ac-b97e-578199388f95"), 2, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b775cb2-4de8-46ca-b031-77c9756893c2"), 4, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0079888e-5d18-463f-a8d9-c04611fc8f92"), 5, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fdbb5fed-e517-4b93-ac56-c87327f373d1"), 6, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e6c1ea62-32cd-465d-ac06-adfdb05d5e3c"), 7, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbc8342d-74e3-4747-a5dd-77e7ff979321"), 8, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b846a4c4-e3f5-4aa1-8d15-0fafce211022"), 9, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("331ef8d6-42c7-48e8-8c32-128c3674d4b1"), 10, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f0900b6-d6c5-4b06-bf09-35befb9c21c1"), 0, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bfe07165-f6b2-4d50-94a4-92befb925f38"), 1, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f6bb130d-5311-4d50-8d7a-034c423a69a6"), 2, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58ccd522-8a23-4d5a-8912-2ccccaab29f6"), 3, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d519b6e6-604a-47e2-8535-422c31ca4830"), 3, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6867424c-9f23-4e59-a017-b3a2fe98e113"), 6, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ff2e826-b4d4-4fa4-82ea-05c82f62488c"), 7, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5794e1cf-0278-4eb4-8b70-14e500b55815"), 0, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da5a6c66-7781-4dba-b13e-1662b77d7ec3"), 12, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a202261-0c4c-4147-ba6e-409226a53fa9"), 0, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0dfbf533-e37f-474f-8ddb-31541e4bb17d"), 1, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("afefa825-d026-49b3-bc3f-8e5c0a08abd2"), 2, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ff36be75-61b2-4688-8a6e-e77864378c02"), 3, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da446a71-2263-4ce5-af72-e90a4c0bb99c"), 4, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("926ba3b7-4eb0-468e-9ce5-fdf411b5ba53"), 5, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("499995b7-cfd1-4649-812e-3d41f9d86cb2"), 6, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5210d13-cdd7-4e37-9e2c-2994f4b8a7fd"), 0, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("608f47dd-b38e-4f86-b1b9-a48e4abc6ce9"), 1, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d5dfc4d-e8c1-4dde-a2b5-273ec1e5de88"), 2, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("402888a2-8ccd-4144-8c8e-5c270cf3c744"), 11, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a5afbdd-a941-48c8-acdb-53e24868f17b"), 3, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a05f6e09-4ce3-4afd-beb0-a6b4e5a8c67c"), 5, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f7dfe1f0-3a9b-45d5-adfd-f5c51680450f"), 6, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6a1891c3-4073-45b8-9768-4c213f0b6b70"), 7, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("38a10ccc-63d4-4d96-a077-bfc8d0e16c21"), 8, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("776fc5e8-a970-4b3e-ae4f-581db167ecf9"), 9, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f0b7b8e-a534-4aed-946c-74149256ef8f"), 10, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92325b2b-112a-4318-9e92-4864343c299e"), 0, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("969e83fe-7edd-493c-a1dc-fdd21314dbcd"), 1, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b566e55a-cce8-4d99-a68a-6b0ae913f85d"), 2, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78540b88-7bfa-499d-82d9-4d5fdaaebffb"), 3, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f0124f80-8f3c-499f-a921-78d0d03e861e"), 4, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d91d4f58-9ee9-4d19-83b4-c93e69f12d7b"), 4, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3abdaeed-d8fe-41e9-97d5-a77a71572f4e"), 10, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dce5cd77-b2c1-4fc3-9fc8-1b3ab7ff7622"), 10, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9e59970e-8e97-4abe-81c2-04c0dfde6026"), 8, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d1afd325-b50c-4125-a77e-8d54bd470813"), 1, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f3fd97af-7774-4626-bce0-a92799dff4a2"), 2, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4672198e-7f6a-4040-b0b8-2aeae7839835"), 3, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("40ad67bb-0575-4471-99e6-52a35ee2e9c5"), 0, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e8656a94-3128-4a79-8c8d-b4a1b9e7ec57"), 1, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2b3b2782-9270-4079-882c-c85157554a7c"), 2, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7a94e399-dd5a-4813-8e2f-25d83089b8f0"), 3, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4db58e89-1394-46a6-8cc5-48251cebea12"), 4, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("09dcf93b-464d-45b4-a7c3-a177e1f6f134"), 5, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8dc5c2ab-4d34-4ef6-8351-ffdf61d2b992"), 6, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6505d57b-3e91-462d-83ad-598764fd10c5"), 7, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("875d90b1-43d7-498c-9741-2339c6fa236c"), 9, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6e402ca-1cc5-4f24-842b-a103aa5f8a19"), 7, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36c45f64-1d0a-4353-ad55-719f40cf8c0f"), 1, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7a26ff79-98d7-4799-923d-f858fb911578"), 2, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dc5d296e-64da-4ab8-83e2-ad422f078b77"), 3, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a357b8a4-fbb4-4a47-94e2-266477b6f32e"), 0, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4a136080-2e25-458f-a646-f2846eace1fb"), 1, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("71e98490-0dae-429e-9a4b-c9d64f1138ce"), 2, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4814e529-eb2f-4460-a0bd-39d01ecc85be"), 3, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("338c1cf2-4bb5-44d0-94af-658e3b556422"), 4, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d6852186-cba9-4357-ac26-bc7dd0ba1eba"), 5, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5e60d05-298f-432d-a6f3-11f99cdb4bdd"), 6, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b55b85cb-f375-467a-b607-a9657a04f7bd"), 7, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a42c7519-d2cc-4ba4-b11b-a5c8301d1226"), 0, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f153ef29-b4ee-49a9-8558-7a9f78db97c2"), 9, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29fb511e-d0c4-465d-9265-52ae824cf081"), 8, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d91643ef-ea82-4316-8cd0-e8b2c7b3299f"), 7, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcb50de6-5b3c-40e2-b62f-4d976ae66416"), 1, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d951996b-f520-4b1a-9ae7-acaee59cc1b5"), 2, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7efb385-4303-428f-a97d-59ec22a79459"), 3, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcafbe1e-270e-4240-bb42-14da8a165d55"), 0, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d66baaf3-1264-46e3-b191-d2d5bf986489"), 1, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4107505a-8892-46e8-881c-3ed8d03d3436"), 2, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("28ea5845-e73f-4fc0-b761-f36d6c9ffed3"), 3, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("386ba1c8-63c8-4080-bc67-21521d5def6f"), 4, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24b772d1-bcc1-4bb7-bb69-177dd2040461"), 5, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a62bab9-9ae7-4948-8a74-83383d0ea6a3"), 6, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("284f6efb-a20d-4a57-8170-e9f0cf2676fd"), 7, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8d76712a-33c4-4646-afff-470d93864640"), 0, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0fdb38ea-2b4f-4beb-b1f4-c2e4016c79ca"), 8, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74e0c60f-7f67-4c91-804d-668cfad6ca82"), 10, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b06cba8f-97bd-4efc-9855-014a6d44e8b6"), 11, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbd8f29c-9c8e-42a5-989f-14517a3ea8e3"), 12, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c9a30de0-a068-4d19-bc9a-e5e7e9350261"), 0, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("79c0ac3c-607f-4a91-aa82-025f6d1d7450"), 1, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8b336e4a-fc45-4f76-91ad-125f908f7d00"), 2, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("617f0399-06f5-461e-8f8d-86bd6f4eeed2"), 3, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ed00969f-9e1f-4b24-b277-df9dd9c633c3"), 4, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a875ee2-5d26-4f38-a552-f3291678cd05"), 5, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c53d3603-6238-4f12-a766-cb5fb05670e5"), 6, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("62cca739-62c4-43e8-b6df-b37cdd70ec02"), 0, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67bbcb4d-a7c0-4669-947e-59c5413202ab"), 9, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5c498a7f-6c0a-4b0d-8a78-d27062ccf7ae"), 1, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e568667c-c324-4aa6-b65e-67d1a2ea45d5"), 7, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2d4f135-b084-4585-93c8-9e36fbd3b8c2"), 6, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b"), 1, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f"), 2, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146"), 3, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("791f737b-f570-45fb-94c5-8e22861d9b2b"), 4, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5193c0a-fcda-43ca-9b3a-79302b2d4fe4"), 5, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89ced772-f3a2-4c99-95ba-79b8de067858"), 6, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bbe9e6f7-0caa-4d2a-b559-d562bdd7c728"), 0, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c516caf8-d319-4f10-820d-93cce49a1b1f"), 1, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c1d0a3bb-4095-4ffd-a2b0-fa3d5c1edb52"), 2, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a12a3379-b4ed-4584-a2ce-328c2da9501d"), 3, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82a4cf88-033b-4d64-9234-131fcc8c0cd7"), 4, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("91474780-b641-43fb-b342-90dd5f19f282"), 7, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("39871f8b-c6f0-4680-9868-9bf1e0a352ba"), 5, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8ec5d9b1-2571-422e-aea6-3d05d5795ed9"), 7, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1b2d6c98-ce4f-4a52-9fdd-7bf7c44aef44"), 0, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3e45c5bb-0fd2-4513-aabc-8f5033d88178"), 1, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7fa8007e-498b-40e3-ae41-ed94f6d9f81e"), 2, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("892dae4f-bcb0-4140-b70a-d7d9ec78269e"), 3, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eeb26208-69f3-43b9-b179-b17e6a03d9d2"), 0, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("87e80e3a-7911-4576-b512-45611fd9ad51"), 1, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("490ccef1-ad72-4ada-ba30-434c4ecd6196"), 2, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58dd3f9b-9f74-472f-a8ae-2c1cd1718cce"), 3, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ec836f7a-bd15-4f22-8c2d-6673297983f4"), 4, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67f501d4-b2d2-41cf-b2b6-e9238d5651c6"), 5, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("643a3dc8-53f5-4fe4-8eff-9657f917b4bc"), 6, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29450890-4e8e-4702-9e62-99db094dc7d4"), 5, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b263fc37-2982-4522-ba51-e6420b827309"), 2, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ba23d332-0f60-48c9-912c-f53fe11505b1"), 4, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a69d4da-fd42-4b8b-a4bd-f2b4e52c40d6"), 0, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7d2e2e4-1f8b-4981-a97f-456633b8bcc5"), 1, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7e1b7fb9-9f46-415a-b482-f661688e7659"), 2, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dc6ef99a-72be-49f6-b592-657717380fbe"), 3, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2746354a-0df5-4f8e-9c15-47a5be653974"), 0, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bd495739-7207-455a-a262-7bf341474c6f"), 1, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a878228d-1daf-4f3d-9bda-ece021ea8a52"), 2, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82b9377f-5a87-4a32-b264-986b61e8d292"), 3, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf9a18ba-c763-40b7-b918-a05dd4b578fc"), 4, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3f3bd248-d49b-4b2e-8561-77665ea8f083"), 5, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d65d4440-afe7-44bc-8e0b-d4ec699fcc6f"), 6, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c325152f-fa03-40e5-a495-52d2ddda9160"), 7, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1eb35899-5c57-41c0-a0bf-e118b015e7fc"), 7, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("422aa4a4-da48-4534-a6f9-5342bc8ed2d9"), 0, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c6b7008-9327-49c3-b6ea-fa72302efe1b"), 1, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0198ed40-e9cc-441c-ad48-6c0022c9c789"), 2, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0022c79-9fd3-4181-b07e-7ef233f9b304"), 3, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("897e584d-86fa-442d-9fa9-3a5cdf7a25c7"), 0, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a75687b7-4f50-4a85-9598-bc45ca3b10ad"), 1, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("068a02c0-2a76-476e-b7e2-ba8042d05c77"), 2, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("01b7fa0d-7a15-4b18-82b9-e7748bdd8649"), 3, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4a1b9e97-7b51-4059-97ae-a9d7237bfdc6"), 4, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("614b3ead-19ff-4e89-a812-87b29a92e331"), 5, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97e331a8-1e12-4a96-8b89-2d8c08717d3f"), 6, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f919abcf-9675-4139-9aba-c56e1cb6b54c"), 7, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7ac0e18-c114-496f-a8cc-d557b8dd6fd7"), 3, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6decf93c-b3d3-4a9a-834f-53f26a27848d"), 6, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("782ed4e8-7e76-4b0e-85c3-21e68c9cbb6d"), 4, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3e5ade45-5fc9-4b09-9d43-ab626b51eeaa"), 5, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2c2dfef9-446f-4ef9-99ef-ea1792ae7d68"), 6, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0232637b-5e8c-4c12-a92a-26866c41f9ca"), 7, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c8603ad6-3940-443d-b37c-fe941592ba5f"), 8, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78652e1e-7e9d-4757-a5c3-f14f49cfa622"), 9, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9731257e-ff4b-45f2-a317-0bb30af2e0da"), 10, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fd9bed8-790d-48f0-8473-5d233340ecaf"), 0, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4cf9c531-f972-4ce0-9f09-d5710731ca45"), 1, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a2a6804-7529-472c-95cc-96989bb34d5d"), 2, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4404a4a5-e27e-4729-922b-8f79f624a053"), 3, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("178c77dc-e783-4b89-afac-7b0835e9d140"), 4, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("371119cc-4e86-44c2-a3c0-478bd47a9ea1"), 5, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1126ba55-b7ee-4b80-b84d-861c6620d4e0"), 5, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2fed809-b4a8-4a37-8e89-c81e046f0d92"), 0, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("66d68f8b-3501-4cee-9630-c28e08b84037"), 1, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0cd36d67-4470-40c9-a386-589da36b9492"), 2, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c033612e-8222-47cb-a244-9fb05bce2e5c"), 3, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("471f5d5d-a69b-4fbb-bb93-5ec7079cac77"), 4, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4557043-2ae6-4276-b949-f8a6a51c284d"), 5, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd2e0d8f-978c-4840-8a55-a36dcd0cc046"), 6, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8bedcad8-826e-4970-a4ec-8a0b3b55f6e6"), 0, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd9aa862-8a09-45ee-9e74-fb6ff59bb9de"), 1, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2da8cf3e-2dc0-446e-8e5b-8b3a1c166adf"), 2, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74f029c4-4e2e-43f1-9788-84dfe1d6ecea"), 3, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("06d53e38-0cd2-45b1-bfd9-aee36e28d62a"), 6, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("235cee46-fd12-4a04-813d-87e6d8bd4212"), 6, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("d64a3082-1867-4221-9a2c-5ce7c83966a3"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("228a4692-b06a-4ac2-8608-5448a05cba72"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("c516caf8-d319-4f10-820d-93cce49a1b1f") },
                    { new Guid("b0cb9792-b914-4c3f-96fd-eb1c48ce2763"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("c91db4e5-2909-4599-a263-c31274e69547"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("c3424e20-04f0-4137-ab14-e03f8a1d3627"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f") },
                    { new Guid("9efb40f2-dec4-41b7-9456-c329e254996f"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f") },
                    { new Guid("0b37dc97-9ffc-4a7e-9269-339b5bd3651f"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b") },
                    { new Guid("bec2e87b-34c1-475a-a81a-d74a622e079b"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b") },
                    { new Guid("5e2e88e3-d845-4b30-bded-f382c2ec3ff7"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("b2a30e8b-95dc-4416-be4e-80100a990d2e"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("2b1460b4-edf4-46ac-91ef-aed394506be3"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("7a5dbced-c757-47ba-86b7-91b937733873"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("16797f2d-9afb-42f9-9b30-69084e80577e"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("76899505-0a20-4581-88c7-a066a334566d"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("51625d5b-63e1-4fe9-b3ba-f57067c751ae"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("905f8b68-3adc-4840-ab3d-c9bfdf0cf7f2"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("46479c5b-616e-4d0a-852c-ca5358f9f40c"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("d80ab46e-c738-49d0-8116-08da0b9340c7"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("c0a67e7b-14ce-469d-b760-aae663a12f11"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("d9084bce-d342-4e37-8777-ecfb74bdc56d"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e822bfc-9337-4ead-af92-029bfa2bdcd3"), 4, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd73cca8-8fb3-4606-a96e-aed3015ad159"), 3, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f65b8cc0-2854-45b4-a8d4-d1abc91e0cb9"), 2, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ba57a80-a63e-488d-a66a-c48b0587969a"), 1, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dd7c94d3-8979-4c63-b4a3-8bc729ba01ec"), 0, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("59b85371-3bbe-46eb-8305-598eb53b365a"), 12, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13072c50-7a79-4b56-82f4-b021e7cec04c"), 11, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a14b0ad-9fb2-488f-9748-4cb39421364f"), 7, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cb6dd9f3-8ddc-4682-9935-8696b6f3926a"), 9, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fb481a14-4dba-42ea-a0cf-eb43c049d965"), 8, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("081dc89e-c4af-4431-882a-18ffac33e1b5"), 6, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7daf9d0a-da1e-4763-bcfd-eb83cdaef700"), 5, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67b87b0c-7ff6-4537-af9b-9ffb630fb1e2"), 4, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6c8aab0-471b-4bc9-a1a5-23dffe441989"), 5, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7c923bd5-f100-48fe-a8a6-116994f622c3"), 10, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f5a5763c-1e7d-43da-b95c-10cb4a8c0392"), 6, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("44b3a671-2ce2-4c3f-9d47-d8f03a23eeb2"), 9, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fc3d15ff-a663-44cb-bfb6-9be7625934a7"), 1, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9994e349-3cba-440d-b951-6fbe9dad9b1a"), 4, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4041011c-840c-440f-a7f7-aca91c68c85c"), 3, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a7ff548-020f-4e06-9801-f90ab9bba2ea"), 2, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b9978a15-a9fc-4b30-ae6e-a3caa6ed50e0"), 1, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("75c26836-3897-4bef-a74a-5a5c1c787aaf"), 0, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f0ef29d-7bcf-4717-b5a6-401a18126557"), 10, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b02e9eaa-eee0-4c32-81b2-21d525c94861"), 0, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c083d3a-4b18-477f-8b74-6eebb0923530"), 3, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97399693-2e64-4714-a907-c13b2c9f9fa4"), 7, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29faa54d-76d7-453f-a349-d52ee37e8927"), 6, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("edc03336-5eb2-46b7-8f65-01f68fa7e30e"), 5, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5f2be98e-fbf9-4f46-b0f8-52b2a14bacd1"), 4, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ec54d4c4-08ff-48de-9025-f9c061634e87"), 3, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24fa36fd-9e03-4368-be1d-080e9e679a5e"), 2, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0d7b796d-4b87-4376-b7da-55121331840f"), 8, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("68b020c3-ae0a-45f0-9a84-60e00a216f3b"), 2, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("abb06c4f-3123-4f05-a5ab-83b7fd88a199"), 5, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("aa39a679-bf39-45c1-be60-422b302e5995"), 0, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0bd28f2b-bb3a-4d78-b912-51d9b16e6a95"), 6, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("adf6a5ab-27d2-41f8-9f56-04d6a5e1eab1"), 5, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("31270d7b-1c02-424b-bd36-0926c786cf12"), 4, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9af2cc90-3b74-4532-b06c-03a7df9f469c"), 3, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d07d073b-4d77-4ca6-b58f-ca585aa1062f"), 2, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("00216c4d-b74c-4a1f-922c-7ee6afade152"), 1, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7c0dff0f-8d1d-4621-be67-6e07f183594e"), 7, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("916b0fa6-658a-43c7-8fdf-6c5634bd68f0"), 0, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5490db04-9a45-4df4-8da3-ee7a98c2fd8f"), 5, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("869eb287-d280-4496-a2b0-034c79740de1"), 4, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cea4c943-7004-4152-9d38-c5abbeb6708d"), 3, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b67b26e-53d3-4741-a3a8-4875b84b26b6"), 2, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7da52905-91ab-4ea2-8bb6-73b6601b8d02"), 1, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ab3a7d64-443f-4fb4-9aa9-d33ee8f1b1f0"), 0, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d74bc6c6-7bb1-42c3-a21a-5ef59ac3dc57"), 6, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0d028c3-8317-45b3-8a58-b6a1eea55bf5"), 1, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89a0ebc5-8e71-4ea4-a3f9-4822f7811c76"), 0, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0c8ea577-fec7-459f-8d7a-cc61304fab9e"), 2, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("945733a8-c533-46b5-b148-81f67ad683cb"), 3, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("209296ec-d07a-4600-9ff1-fd9b015220f7"), 2, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("17db6a19-3549-4e36-8334-38c390fb93a6"), 1, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eaea3a53-0196-45e7-87b5-0d4224d8e036"), 0, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5626439e-8f52-45f5-8ab1-651568732ad9"), 7, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d3e386fd-2536-4a53-82c5-26cc8daac3d8"), 7, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5e2e8537-d4e3-4be9-b363-fb15adcbe149"), 1, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e4f15bd2-95dc-41a8-8a48-196ea2a633bf"), 6, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bd46bbf2-e847-413a-9eb2-3f4d6d5f3469"), 4, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("86304bf9-ad46-49c1-b172-f1f983c6cdd8"), 3, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ddbc8bd-abcc-41fb-844c-db019ff97bbb"), 2, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("90fbcf3d-9628-41dc-8850-9dceb4bd3956"), 1, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5117871-e694-4e39-9f33-73f69339eded"), 0, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fb30e6f-01b1-4a09-947b-ba02992d1186"), 3, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("476daad7-0bb3-4005-be72-65dc809f81c9"), 5, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0346789-a6b6-478a-a48c-7459dd93a6c2"), 6, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse strong band" });

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