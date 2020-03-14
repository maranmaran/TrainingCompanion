using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class SystemLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemExceptions");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("09dbc54c-2588-40c8-93b3-926d77e8d085"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("41537554-2054-42a0-944e-1c94a8a7d41b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("4414dceb-0bab-46d1-89c8-b49c20c18011"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("7acd7cd3-d5ed-44c6-8742-3952a6a6a64d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("7b01a162-82ac-4ce2-abda-ec48cbba56e6"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("868d1297-e9d6-4d91-81be-1583fecd6357"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8dfb43ed-4023-4c3e-8fad-1234b7ad0a19"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("92a9ffec-66b5-46de-92a5-51b33ed7beac"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9c544ae3-8315-4cee-b862-0faa6ea1e61c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c16450f0-483f-4ac0-9d5a-f33b5044d302"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c3326dfd-c4ea-4056-92b7-7ce3064fd7e1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("de2934cd-fbc1-4fd8-8423-f2566ad7f7c2"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e5ba6b3a-bf68-43f8-8203-57ae72407c59"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("efe9037b-55bc-4687-8d5c-f41a4d33d379"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fa2cd68d-d2e0-43b9-8443-2e85537adab0"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fe4cd3b8-0c83-47bc-a1c7-b14267ba0e2a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5e2dfad-cd1b-4056-a7fa-e12a7702b4a4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e055fbd8-8cd2-417a-883b-832f36a3a882"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b481a09-bd81-4002-a80c-5b7a8d63d6c9"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("5393d2df-b412-45be-801e-4cf1969477a3"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("81044559-e8e0-46ab-8501-4616949c5401"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("cd17378f-409a-471e-82c8-c8b3149cae21"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2f92731d-b5dc-4ca2-93ff-ba3287e2676d"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e"));

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

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId" },
                values: new object[,]
                {
                    { new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0"), new Guid("0641315b-051f-4ad4-b3ad-de324ba6dc1f"), null },
                    { new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff"), new Guid("22434b7e-df67-4ae1-a58a-9cf324fe438f"), null },
                    { new Guid("7bc57904-36e1-4593-b706-222c09e1c110"), new Guid("cfa6bfee-a1ce-4783-8350-aa1f92698898"), null },
                    { new Guid("fc77650c-ea63-465d-b2ea-db4645366436"), new Guid("102552fe-dab6-4c88-8601-77e6724e1fa0"), null }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("6503e9b5-67f5-451f-bddc-4d8722dfaf24"), "ImportFinished", new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff") },
                    { new Guid("ae024392-e6c7-449c-80e2-2b9627d1178e"), "TrainingCreated", new Guid("fc77650c-ea63-465d-b2ea-db4645366436") },
                    { new Guid("258e4151-1578-4223-b9b4-42760a2faece"), "ImportFinished", new Guid("7bc57904-36e1-4593-b706-222c09e1c110") },
                    { new Guid("65b1f971-e87e-4c81-b8f9-00d5481f1400"), "MediaAdded", new Guid("7bc57904-36e1-4593-b706-222c09e1c110") },
                    { new Guid("911cf91f-b47e-48f5-a4d9-051f4000f743"), "NoteAdded", new Guid("7bc57904-36e1-4593-b706-222c09e1c110") },
                    { new Guid("3619e870-7193-4ec2-92ee-b3326cb606b3"), "TrainingCreated", new Guid("7bc57904-36e1-4593-b706-222c09e1c110") },
                    { new Guid("25e8761f-9196-40ce-9a21-d0ebf7430d1d"), "ImportFinished", new Guid("fc77650c-ea63-465d-b2ea-db4645366436") },
                    { new Guid("9f875071-b420-48f4-9699-e6fb8bf9c58c"), "NoteAdded", new Guid("fc77650c-ea63-465d-b2ea-db4645366436") },
                    { new Guid("b06c2675-989d-4aab-a330-6e1d3c9ec506"), "MediaAdded", new Guid("fc77650c-ea63-465d-b2ea-db4645366436") },
                    { new Guid("467ddfd3-f933-48e9-991c-7f9d47df6f06"), "NoteAdded", new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff") },
                    { new Guid("5775942e-ba20-412c-8b99-7ff55c917ea1"), "TrainingCreated", new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff") },
                    { new Guid("9e1c2553-31f5-4df1-9243-f055b4db6bfd"), "ImportFinished", new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0") },
                    { new Guid("d415de29-f103-4dac-af1a-4f29f6f25e4a"), "MediaAdded", new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0") },
                    { new Guid("845274c4-a717-4195-94ac-7df9c3bd041f"), "NoteAdded", new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0") },
                    { new Guid("56c344ee-7eb9-40bc-bc57-099db6af761c"), "TrainingCreated", new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0") },
                    { new Guid("8efe1f06-9a72-4b6e-9dd9-80ab4aeff2ea"), "MediaAdded", new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("0641315b-051f-4ad4-b3ad-de324ba6dc1f"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=733037&color=ffffff&", new DateTime(2020, 3, 14, 22, 43, 46, 911, DateTimeKind.Utc).AddTicks(6426), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0"), "admin" },
                    { new Guid("cfa6bfee-a1ce-4783-8350-aa1f92698898"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=D56C8E&color=ffffff&", new DateTime(2020, 3, 14, 22, 43, 46, 912, DateTimeKind.Utc).AddTicks(2759), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("7bc57904-36e1-4593-b706-222c09e1c110"), "coach" },
                    { new Guid("102552fe-dab6-4c88-8601-77e6724e1fa0"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=FBF291&color=ffffff&", new DateTime(2020, 3, 14, 22, 43, 46, 912, DateTimeKind.Utc).AddTicks(963), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("fc77650c-ea63-465d-b2ea-db4645366436"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("22434b7e-df67-4ae1-a58a-9cf324fe438f"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=EF7D6B&color=ffffff&", new DateTime(2020, 3, 14, 22, 43, 46, 912, DateTimeKind.Utc).AddTicks(243), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff"), "athlete", new Guid("cfa6bfee-a1ce-4783-8350-aa1f92698898") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemLog");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("258e4151-1578-4223-b9b4-42760a2faece"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("25e8761f-9196-40ce-9a21-d0ebf7430d1d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3619e870-7193-4ec2-92ee-b3326cb606b3"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("467ddfd3-f933-48e9-991c-7f9d47df6f06"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("56c344ee-7eb9-40bc-bc57-099db6af761c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5775942e-ba20-412c-8b99-7ff55c917ea1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6503e9b5-67f5-451f-bddc-4d8722dfaf24"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("65b1f971-e87e-4c81-b8f9-00d5481f1400"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("845274c4-a717-4195-94ac-7df9c3bd041f"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8efe1f06-9a72-4b6e-9dd9-80ab4aeff2ea"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("911cf91f-b47e-48f5-a4d9-051f4000f743"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9e1c2553-31f5-4df1-9243-f055b4db6bfd"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9f875071-b420-48f4-9699-e6fb8bf9c58c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ae024392-e6c7-449c-80e2-2b9627d1178e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b06c2675-989d-4aab-a330-6e1d3c9ec506"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d415de29-f103-4dac-af1a-4f29f6f25e4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0641315b-051f-4ad4-b3ad-de324ba6dc1f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22434b7e-df67-4ae1-a58a-9cf324fe438f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("102552fe-dab6-4c88-8601-77e6724e1fa0"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("0cb7c637-2b7a-4ef5-85d7-59d5e2fb3aff"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("bf5da2f5-d545-406f-9afd-903980d7dac0"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("fc77650c-ea63-465d-b2ea-db4645366436"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfa6bfee-a1ce-4783-8350-aa1f92698898"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("7bc57904-36e1-4593-b706-222c09e1c110"));

            migrationBuilder.CreateTable(
                name: "SystemExceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemExceptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[,]
                {
                    { new Guid("81044559-e8e0-46ab-8501-4616949c5401"), new Guid("a5e2dfad-cd1b-4056-a7fa-e12a7702b4a4"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("cd17378f-409a-471e-82c8-c8b3149cae21"), new Guid("e055fbd8-8cd2-417a-883b-832f36a3a882"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e"), new Guid("2f92731d-b5dc-4ca2-93ff-ba3287e2676d"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("5393d2df-b412-45be-801e-4cf1969477a3"), new Guid("9b481a09-bd81-4002-a80c-5b7a8d63d6c9"), null, "Rpe", "Light", "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("9c544ae3-8315-4cee-b862-0faa6ea1e61c"), "ImportFinished", new Guid("cd17378f-409a-471e-82c8-c8b3149cae21") },
                    { new Guid("efe9037b-55bc-4687-8d5c-f41a4d33d379"), "TrainingCreated", new Guid("5393d2df-b412-45be-801e-4cf1969477a3") },
                    { new Guid("e5ba6b3a-bf68-43f8-8203-57ae72407c59"), "ImportFinished", new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e") },
                    { new Guid("41537554-2054-42a0-944e-1c94a8a7d41b"), "MediaAdded", new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e") },
                    { new Guid("4414dceb-0bab-46d1-89c8-b49c20c18011"), "NoteAdded", new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e") },
                    { new Guid("de2934cd-fbc1-4fd8-8423-f2566ad7f7c2"), "TrainingCreated", new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e") },
                    { new Guid("7acd7cd3-d5ed-44c6-8742-3952a6a6a64d"), "ImportFinished", new Guid("5393d2df-b412-45be-801e-4cf1969477a3") },
                    { new Guid("868d1297-e9d6-4d91-81be-1583fecd6357"), "NoteAdded", new Guid("5393d2df-b412-45be-801e-4cf1969477a3") },
                    { new Guid("8dfb43ed-4023-4c3e-8fad-1234b7ad0a19"), "MediaAdded", new Guid("5393d2df-b412-45be-801e-4cf1969477a3") },
                    { new Guid("92a9ffec-66b5-46de-92a5-51b33ed7beac"), "NoteAdded", new Guid("cd17378f-409a-471e-82c8-c8b3149cae21") },
                    { new Guid("7b01a162-82ac-4ce2-abda-ec48cbba56e6"), "TrainingCreated", new Guid("cd17378f-409a-471e-82c8-c8b3149cae21") },
                    { new Guid("c3326dfd-c4ea-4056-92b7-7ce3064fd7e1"), "ImportFinished", new Guid("81044559-e8e0-46ab-8501-4616949c5401") },
                    { new Guid("09dbc54c-2588-40c8-93b3-926d77e8d085"), "MediaAdded", new Guid("81044559-e8e0-46ab-8501-4616949c5401") },
                    { new Guid("fe4cd3b8-0c83-47bc-a1c7-b14267ba0e2a"), "NoteAdded", new Guid("81044559-e8e0-46ab-8501-4616949c5401") },
                    { new Guid("fa2cd68d-d2e0-43b9-8443-2e85537adab0"), "TrainingCreated", new Guid("81044559-e8e0-46ab-8501-4616949c5401") },
                    { new Guid("c16450f0-483f-4ac0-9d5a-f33b5044d302"), "MediaAdded", new Guid("cd17378f-409a-471e-82c8-c8b3149cae21") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("a5e2dfad-cd1b-4056-a7fa-e12a7702b4a4"), "User", null, new DateTime(2020, 3, 14, 22, 22, 22, 872, DateTimeKind.Utc).AddTicks(5771), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("81044559-e8e0-46ab-8501-4616949c5401"), "admin" },
                    { new Guid("2f92731d-b5dc-4ca2-93ff-ba3287e2676d"), "User", null, new DateTime(2020, 3, 14, 22, 22, 22, 873, DateTimeKind.Utc).AddTicks(2490), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("d69b91bc-bc7e-49be-8f0b-018eceaca93e"), "coach" },
                    { new Guid("9b481a09-bd81-4002-a80c-5b7a8d63d6c9"), "User", null, new DateTime(2020, 3, 14, 22, 22, 22, 873, DateTimeKind.Utc).AddTicks(876), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("5393d2df-b412-45be-801e-4cf1969477a3"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("e055fbd8-8cd2-417a-883b-832f36a3a882"), "User", null, new DateTime(2020, 3, 14, 22, 22, 22, 873, DateTimeKind.Utc).AddTicks(185), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("cd17378f-409a-471e-82c8-c8b3149cae21"), "athlete", new Guid("2f92731d-b5dc-4ca2-93ff-ba3287e2676d") });
        }
    }
}
