using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("04f7b168-34f6-46c1-b01f-1e1366de93fc"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0e68e06b-ef6b-4a8c-b735-25dc5d357b96"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("15491940-1394-4a7a-b2c7-3159f98ef212"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("15e5e012-1295-4770-9511-5abcb4f2eb60"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2bcfbdc1-0b14-40b1-ab0a-799f7a3c2640"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2c737793-6ba1-4a49-8c23-518b79dde5a7"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5d747370-b9e3-42a5-a71e-dfd68e2524d1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("658bec95-e200-4bf6-a0f0-1921ee658a47"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6ebffec1-98f1-44e5-be0a-ab97bfc51eb4"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("70c9dddc-63e5-4242-9556-a84b6a2f1ea4"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a78a5065-9e8a-4b64-aebb-2d329d2846c0"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b367bbb5-a68a-485f-8fbb-7ea9932d57f4"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("baa0e077-bff2-4851-9095-c1c600933b4d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ed8264ab-1860-49db-90da-1a507d313988"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f328bfed-a019-4a6d-8312-faca6f5ae1e8"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fc1c287b-e72f-4626-b748-f0f361ac8bce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9019878b-85d2-4bd0-99f7-ff1faaf018c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f78bdd8-1495-481b-a620-8a178b7a2cb5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7f158861-3696-4ffd-b830-534419b85ad7"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("575bc4e5-7ae6-469b-bcc2-b7c00bc9a5e9"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("69c7e5a5-4563-449b-9c8d-788147684588"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId" },
                values: new object[,]
                {
                    { new Guid("08ee7004-3e49-4093-9649-a544565265d3"), new Guid("cd2fbc36-65bb-44bb-9269-5748923b21e9"), null },
                    { new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb"), new Guid("3823fdab-c8b8-4921-9ad2-55727936f0c1"), null },
                    { new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0"), new Guid("962ee222-f961-4984-985d-72a803e7ae0e"), null },
                    { new Guid("cf33c27d-af75-4d20-be23-72742e347867"), new Guid("be0ae43a-25b2-410c-a645-30861526076f"), null }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("48bf9d71-15dc-4dac-b682-db6964f9cd49"), "PersonalBestAdded", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") },
                    { new Guid("3ddb6fad-87ab-4411-8523-41dcb2a4bb42"), "MediaAdded", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("517db1ee-8323-450c-a471-0d00804a4616"), "NoteAdded", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("0153bdf2-a955-43e9-af15-7edc5ed8cc57"), "TrainingCreated", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("a0e53b11-f3a3-4e2b-b047-1e07a20abba9"), "PersonalBestAdded", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("d866cdfe-3b70-42f5-ac9f-0f7354c7e6fd"), "BodyweightAdded", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("ead65900-ce32-46ce-8cb2-5cd2a53bdac7"), "ImportFinished", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("f1b6cdb5-d8e1-419b-b543-a88e3a31c385"), "MediaAdded", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("b05c3356-6361-4041-8ad2-bb135b9d19b1"), "NoteAdded", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("52023241-1519-4ff7-b10f-2c424d13cf21"), "TrainingCreated", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0") },
                    { new Guid("530ca140-49a8-4576-a27c-854b6e001218"), "PersonalBestAdded", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("6ab5ede3-adfe-4b31-851c-b528f7256c31"), "ImportFinished", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("fb20fa6e-2064-4d6f-8e47-3d1bc95b0a31"), "BodyweightAdded", new Guid("cf33c27d-af75-4d20-be23-72742e347867") },
                    { new Guid("2314eff9-d4fd-4e39-ac34-4df59624907c"), "ImportFinished", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") },
                    { new Guid("c0329313-82f4-4172-91b0-64698599d2bc"), "MediaAdded", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") },
                    { new Guid("6ca101aa-3ca2-4ce9-8776-025391893e50"), "NoteAdded", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") },
                    { new Guid("3a31e75e-4651-42d9-baae-5ce5bfa34f36"), "TrainingCreated", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") },
                    { new Guid("a2294ca1-e2b6-4d52-a1cf-bd2616a06d56"), "PersonalBestAdded", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("57646ddc-87b2-49c3-b413-1c3fb600d076"), "BodyweightAdded", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("e792a157-4cb5-4f2a-8566-f3bce65445a3"), "ImportFinished", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("bf2468c6-e58a-41a8-89c4-1057049614ae"), "MediaAdded", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("a10ab8c0-d633-4d1f-a8f9-34ad87c26200"), "NoteAdded", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("af5887e9-8006-4ce3-bf5e-a21c7bdd429b"), "TrainingCreated", new Guid("08ee7004-3e49-4093-9649-a544565265d3") },
                    { new Guid("b5b3f332-4e5c-4ccd-8f3a-5432524f6632"), "BodyweightAdded", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("cd2fbc36-65bb-44bb-9269-5748923b21e9"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=921A97&color=ffffff&", new DateTime(2020, 3, 21, 16, 34, 39, 153, DateTimeKind.Utc).AddTicks(5215), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("08ee7004-3e49-4093-9649-a544565265d3"), "admin" },
                    { new Guid("962ee222-f961-4984-985d-72a803e7ae0e"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=BB3052&color=ffffff&", new DateTime(2020, 3, 21, 16, 34, 39, 154, DateTimeKind.Utc).AddTicks(1772), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0"), "coach" },
                    { new Guid("be0ae43a-25b2-410c-a645-30861526076f"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=C15DC4&color=ffffff&", new DateTime(2020, 3, 21, 16, 34, 39, 153, DateTimeKind.Utc).AddTicks(9876), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("cf33c27d-af75-4d20-be23-72742e347867"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("3823fdab-c8b8-4921-9ad2-55727936f0c1"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=00AE67&color=ffffff&", new DateTime(2020, 3, 21, 16, 34, 39, 153, DateTimeKind.Utc).AddTicks(9058), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb"), "athlete", new Guid("962ee222-f961-4984-985d-72a803e7ae0e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0153bdf2-a955-43e9-af15-7edc5ed8cc57"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2314eff9-d4fd-4e39-ac34-4df59624907c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3a31e75e-4651-42d9-baae-5ce5bfa34f36"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3ddb6fad-87ab-4411-8523-41dcb2a4bb42"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("48bf9d71-15dc-4dac-b682-db6964f9cd49"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("517db1ee-8323-450c-a471-0d00804a4616"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("52023241-1519-4ff7-b10f-2c424d13cf21"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("530ca140-49a8-4576-a27c-854b6e001218"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("57646ddc-87b2-49c3-b413-1c3fb600d076"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6ab5ede3-adfe-4b31-851c-b528f7256c31"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6ca101aa-3ca2-4ce9-8776-025391893e50"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a0e53b11-f3a3-4e2b-b047-1e07a20abba9"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a10ab8c0-d633-4d1f-a8f9-34ad87c26200"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a2294ca1-e2b6-4d52-a1cf-bd2616a06d56"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("af5887e9-8006-4ce3-bf5e-a21c7bdd429b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b05c3356-6361-4041-8ad2-bb135b9d19b1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b5b3f332-4e5c-4ccd-8f3a-5432524f6632"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("bf2468c6-e58a-41a8-89c4-1057049614ae"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c0329313-82f4-4172-91b0-64698599d2bc"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d866cdfe-3b70-42f5-ac9f-0f7354c7e6fd"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e792a157-4cb5-4f2a-8566-f3bce65445a3"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ead65900-ce32-46ce-8cb2-5cd2a53bdac7"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f1b6cdb5-d8e1-419b-b543-a88e3a31c385"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fb20fa6e-2064-4d6f-8e47-3d1bc95b0a31"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd2fbc36-65bb-44bb-9269-5748923b21e9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3823fdab-c8b8-4921-9ad2-55727936f0c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be0ae43a-25b2-410c-a645-30861526076f"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("08ee7004-3e49-4093-9649-a544565265d3"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("cf33c27d-af75-4d20-be23-72742e347867"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("e0e2e219-2dee-482d-b951-2aed707cd5cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("962ee222-f961-4984-985d-72a803e7ae0e"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("8427aa7e-faa7-467e-853d-5df74b6d98a0"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[,]
                {
                    { new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a"), new Guid("9019878b-85d2-4bd0-99f7-ff1faaf018c9"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9"), new Guid("9f78bdd8-1495-481b-a620-8a178b7a2cb5"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("69c7e5a5-4563-449b-9c8d-788147684588"), new Guid("575bc4e5-7ae6-469b-bcc2-b7c00bc9a5e9"), null, "Rpe", "Light", "Imperial" },
                    { new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d"), new Guid("7f158861-3696-4ffd-b830-534419b85ad7"), null, "Rpe", "Light", "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("6ebffec1-98f1-44e5-be0a-ab97bfc51eb4"), "ImportFinished", new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9") },
                    { new Guid("baa0e077-bff2-4851-9095-c1c600933b4d"), "TrainingCreated", new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d") },
                    { new Guid("5d747370-b9e3-42a5-a71e-dfd68e2524d1"), "ImportFinished", new Guid("69c7e5a5-4563-449b-9c8d-788147684588") },
                    { new Guid("2c737793-6ba1-4a49-8c23-518b79dde5a7"), "MediaAdded", new Guid("69c7e5a5-4563-449b-9c8d-788147684588") },
                    { new Guid("ed8264ab-1860-49db-90da-1a507d313988"), "NoteAdded", new Guid("69c7e5a5-4563-449b-9c8d-788147684588") },
                    { new Guid("04f7b168-34f6-46c1-b01f-1e1366de93fc"), "TrainingCreated", new Guid("69c7e5a5-4563-449b-9c8d-788147684588") },
                    { new Guid("fc1c287b-e72f-4626-b748-f0f361ac8bce"), "ImportFinished", new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d") },
                    { new Guid("2bcfbdc1-0b14-40b1-ab0a-799f7a3c2640"), "NoteAdded", new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d") },
                    { new Guid("0e68e06b-ef6b-4a8c-b735-25dc5d357b96"), "MediaAdded", new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d") },
                    { new Guid("70c9dddc-63e5-4242-9556-a84b6a2f1ea4"), "NoteAdded", new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9") },
                    { new Guid("658bec95-e200-4bf6-a0f0-1921ee658a47"), "TrainingCreated", new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9") },
                    { new Guid("a78a5065-9e8a-4b64-aebb-2d329d2846c0"), "ImportFinished", new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a") },
                    { new Guid("15e5e012-1295-4770-9511-5abcb4f2eb60"), "MediaAdded", new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a") },
                    { new Guid("15491940-1394-4a7a-b2c7-3159f98ef212"), "NoteAdded", new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a") },
                    { new Guid("b367bbb5-a68a-485f-8fbb-7ea9932d57f4"), "TrainingCreated", new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a") },
                    { new Guid("f328bfed-a019-4a6d-8312-faca6f5ae1e8"), "MediaAdded", new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("9019878b-85d2-4bd0-99f7-ff1faaf018c9"), "User", null, new DateTime(2020, 3, 16, 11, 12, 40, 737, DateTimeKind.Utc).AddTicks(8906), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("de6da0b9-7754-445d-ae09-5434669e8f2a"), "admin" },
                    { new Guid("575bc4e5-7ae6-469b-bcc2-b7c00bc9a5e9"), "User", null, new DateTime(2020, 3, 16, 11, 12, 40, 738, DateTimeKind.Utc).AddTicks(5278), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("69c7e5a5-4563-449b-9c8d-788147684588"), "coach" },
                    { new Guid("7f158861-3696-4ffd-b830-534419b85ad7"), "User", null, new DateTime(2020, 3, 16, 11, 12, 40, 738, DateTimeKind.Utc).AddTicks(3575), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("dcfa27d7-9247-4380-bae3-22c7d917716d"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("9f78bdd8-1495-481b-a620-8a178b7a2cb5"), "User", null, new DateTime(2020, 3, 16, 11, 12, 40, 738, DateTimeKind.Utc).AddTicks(2833), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("7cdc860a-7a52-4e1b-8c8d-095a7b77b0f9"), "athlete", new Guid("575bc4e5-7ae6-469b-bcc2-b7c00bc9a5e9") });
        }
    }
}
