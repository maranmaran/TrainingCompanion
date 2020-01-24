using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class NonUniqueCode_TrackItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrackItems_Code",
                table: "TrackItems");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("09b41946-e4a4-4321-aaf8-2b5dee66f114"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("10bb066a-4a23-4cbb-ac3d-f90af43ddd71"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("1b7d4551-85ff-4a5c-8550-e90bced90688"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("225715fd-fab9-4d1a-a238-6a424bc873c3"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("24019cf4-7699-4a8a-b8d6-0a5fe1fd6368"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("245fb0e2-c69e-4288-889b-88ad10b129ee"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3ce097a2-c4ed-4b9a-8fde-a015663c5908"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("49f6a7f0-e8e7-4229-bbfa-55682ec63646"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6eab1018-c6a5-46ab-b348-07c9d0a2933c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a051c95f-4b2f-4783-9c95-731c29f32655"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a7a7a282-1a46-4aa1-90ed-711d44e096d9"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c0aed161-8f29-4eeb-8019-048242e26ca1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c794b10b-394d-41bf-aa47-bf1d1a5569a9"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("cccd2988-6736-4d2f-8b49-a6427350faad"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("dacc537b-0caa-41c9-9eb9-af630e300f0c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e3968fa6-f6db-475e-9e48-670098655ed1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("afb29824-fc83-45c4-81e7-9e4efc88e755"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41c94845-7334-4085-a7ea-20a7ce0dc6c4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7df3babf-8fad-4eb2-ae99-67c994a3272c"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bcb96d70-d7e6-496d-a618-7fba94b6af2d"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TrackItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TrackItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[,]
                {
                    { new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27"), new Guid("afb29824-fc83-45c4-81e7-9e4efc88e755"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d"), new Guid("41c94845-7334-4085-a7ea-20a7ce0dc6c4"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b"), new Guid("bcb96d70-d7e6-496d-a618-7fba94b6af2d"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98"), new Guid("7df3babf-8fad-4eb2-ae99-67c994a3272c"), null, "Rpe", "Light", "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("10bb066a-4a23-4cbb-ac3d-f90af43ddd71"), "ImportFinished", new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d") },
                    { new Guid("dacc537b-0caa-41c9-9eb9-af630e300f0c"), "TrainingCreated", new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98") },
                    { new Guid("1b7d4551-85ff-4a5c-8550-e90bced90688"), "ImportFinished", new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b") },
                    { new Guid("3ce097a2-c4ed-4b9a-8fde-a015663c5908"), "MediaAdded", new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b") },
                    { new Guid("c794b10b-394d-41bf-aa47-bf1d1a5569a9"), "NoteAdded", new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b") },
                    { new Guid("6eab1018-c6a5-46ab-b348-07c9d0a2933c"), "TrainingCreated", new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b") },
                    { new Guid("a7a7a282-1a46-4aa1-90ed-711d44e096d9"), "ImportFinished", new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98") },
                    { new Guid("a051c95f-4b2f-4783-9c95-731c29f32655"), "NoteAdded", new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98") },
                    { new Guid("cccd2988-6736-4d2f-8b49-a6427350faad"), "MediaAdded", new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98") },
                    { new Guid("225715fd-fab9-4d1a-a238-6a424bc873c3"), "NoteAdded", new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d") },
                    { new Guid("c0aed161-8f29-4eeb-8019-048242e26ca1"), "TrainingCreated", new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d") },
                    { new Guid("24019cf4-7699-4a8a-b8d6-0a5fe1fd6368"), "ImportFinished", new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27") },
                    { new Guid("245fb0e2-c69e-4288-889b-88ad10b129ee"), "MediaAdded", new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27") },
                    { new Guid("e3968fa6-f6db-475e-9e48-670098655ed1"), "NoteAdded", new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27") },
                    { new Guid("09b41946-e4a4-4321-aaf8-2b5dee66f114"), "TrainingCreated", new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27") },
                    { new Guid("49f6a7f0-e8e7-4229-bbfa-55682ec63646"), "MediaAdded", new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("afb29824-fc83-45c4-81e7-9e4efc88e755"), "User", null, new DateTime(2020, 1, 24, 19, 29, 47, 43, DateTimeKind.Utc).AddTicks(6210), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("ec3e408c-8851-4c78-a58f-578c3e9e0d27"), "admin" },
                    { new Guid("bcb96d70-d7e6-496d-a618-7fba94b6af2d"), "User", null, new DateTime(2020, 1, 24, 19, 29, 47, 44, DateTimeKind.Utc).AddTicks(2014), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("bcd6fece-e0cc-4ca3-a839-c4d6251ebf3b"), "coach" },
                    { new Guid("7df3babf-8fad-4eb2-ae99-67c994a3272c"), "User", null, new DateTime(2020, 1, 24, 19, 29, 47, 44, DateTimeKind.Utc).AddTicks(475), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("799cbd43-f923-42c1-b4dc-d28567cffe98"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("41c94845-7334-4085-a7ea-20a7ce0dc6c4"), "User", null, new DateTime(2020, 1, 24, 19, 29, 47, 43, DateTimeKind.Utc).AddTicks(9784), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("b08aacec-9cf0-40cc-8d0e-39033a1dc33d"), "athlete", new Guid("bcb96d70-d7e6-496d-a618-7fba94b6af2d") });

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_Code",
                table: "TrackItems",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
