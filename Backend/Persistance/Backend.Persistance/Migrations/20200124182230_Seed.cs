//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace Backend.Persistance.Migrations
//{
//    public partial class Seed : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.InsertData(
//                table: "UserSettings",
//                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId" },
//                values: new object[,]
//                {
//                    { new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce"), new Guid("a7e887a7-4e76-4f96-b0e5-d12ac9503ccc"), null },
//                    { new Guid("09673314-6eb4-423e-a93c-34b4126a02cc"), new Guid("85d80fa1-e21b-4b19-8725-471ee3bcc338"), null },
//                    { new Guid("e67b4e66-7e71-4749-933d-027ca0ace096"), new Guid("80714178-6faa-4ddf-b9b5-63f1b2932b2e"), null },
//                    { new Guid("28d6238e-40ab-4503-b293-bd6867de983b"), new Guid("c34c7468-09db-493e-b802-c0322f969e3c"), null }
//                });

//            migrationBuilder.InsertData(
//                table: "NotificationSetting",
//                columns: new[] { "Id", "NotificationType", "UserSettingId" },
//                values: new object[,]
//                {
//                    { new Guid("86827f03-fa70-4c54-8396-72e6c03885e2"), "ImportFinished", new Guid("09673314-6eb4-423e-a93c-34b4126a02cc") },
//                    { new Guid("842c1012-4b3b-4df8-8271-cb1b22e48574"), "TrainingCreated", new Guid("28d6238e-40ab-4503-b293-bd6867de983b") },
//                    { new Guid("372edd3c-8281-43c3-bc0c-5846ba1d1d7f"), "ImportFinished", new Guid("e67b4e66-7e71-4749-933d-027ca0ace096") },
//                    { new Guid("69cba466-278b-4ffa-830f-394e4fb9b648"), "MediaAdded", new Guid("e67b4e66-7e71-4749-933d-027ca0ace096") },
//                    { new Guid("f57c4bd5-1752-45fb-a54e-d52ee5f62392"), "NoteAdded", new Guid("e67b4e66-7e71-4749-933d-027ca0ace096") },
//                    { new Guid("df8e635c-e1ef-4b50-a5d8-455849220863"), "TrainingCreated", new Guid("e67b4e66-7e71-4749-933d-027ca0ace096") },
//                    { new Guid("62cd2f9a-c540-4b18-b4c8-6562c53ab8ad"), "ImportFinished", new Guid("28d6238e-40ab-4503-b293-bd6867de983b") },
//                    { new Guid("dfd2dc5d-4f68-4b05-9190-9b22f03d8281"), "NoteAdded", new Guid("28d6238e-40ab-4503-b293-bd6867de983b") },
//                    { new Guid("44046913-4497-4c92-b03e-7f1e6fba6089"), "MediaAdded", new Guid("28d6238e-40ab-4503-b293-bd6867de983b") },
//                    { new Guid("c181243c-f8ab-4f96-b5d7-ac83dbdacc38"), "NoteAdded", new Guid("09673314-6eb4-423e-a93c-34b4126a02cc") },
//                    { new Guid("0a173e02-24d4-4a9f-a333-64f54e15adba"), "TrainingCreated", new Guid("09673314-6eb4-423e-a93c-34b4126a02cc") },
//                    { new Guid("0ee59293-05e0-48b3-9a03-d707691db30b"), "ImportFinished", new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce") },
//                    { new Guid("51789d68-d1a0-49c8-b048-1cf77d8f375f"), "MediaAdded", new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce") },
//                    { new Guid("8bc760de-28ee-4ac1-8f36-1791398e2cbb"), "NoteAdded", new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce") },
//                    { new Guid("2049eacd-5294-4e15-abb2-4a63b822b1d0"), "TrainingCreated", new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce") },
//                    { new Guid("f5073484-eb49-43c7-91d7-537e5a06309a"), "MediaAdded", new Guid("09673314-6eb4-423e-a93c-34b4126a02cc") }
//                });

//            migrationBuilder.InsertData(
//                table: "Users",
//                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
//                values: new object[,]
//                {
//                    { new Guid("a7e887a7-4e76-4f96-b0e5-d12ac9503ccc"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=E03557&color=ffffff&", new DateTime(2020, 1, 24, 18, 22, 29, 874, DateTimeKind.Utc).AddTicks(7950), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce"), "admin" },
//                    { new Guid("80714178-6faa-4ddf-b9b5-63f1b2932b2e"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=243166&color=ffffff&", new DateTime(2020, 1, 24, 18, 22, 29, 875, DateTimeKind.Utc).AddTicks(4423), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("e67b4e66-7e71-4749-933d-027ca0ace096"), "coach" },
//                    { new Guid("c34c7468-09db-493e-b802-c0322f969e3c"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=67305E&color=ffffff&", new DateTime(2020, 1, 24, 18, 22, 29, 875, DateTimeKind.Utc).AddTicks(2596), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("28d6238e-40ab-4503-b293-bd6867de983b"), "soloathlete" }
//                });

//            migrationBuilder.InsertData(
//                table: "Users",
//                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
//                values: new object[] { new Guid("85d80fa1-e21b-4b19-8725-471ee3bcc338"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=020750&color=ffffff&", new DateTime(2020, 1, 24, 18, 22, 29, 875, DateTimeKind.Utc).AddTicks(1700), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("09673314-6eb4-423e-a93c-34b4126a02cc"), "athlete", new Guid("80714178-6faa-4ddf-b9b5-63f1b2932b2e") });
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("0a173e02-24d4-4a9f-a333-64f54e15adba"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("0ee59293-05e0-48b3-9a03-d707691db30b"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("2049eacd-5294-4e15-abb2-4a63b822b1d0"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("372edd3c-8281-43c3-bc0c-5846ba1d1d7f"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("44046913-4497-4c92-b03e-7f1e6fba6089"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("51789d68-d1a0-49c8-b048-1cf77d8f375f"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("62cd2f9a-c540-4b18-b4c8-6562c53ab8ad"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("69cba466-278b-4ffa-830f-394e4fb9b648"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("842c1012-4b3b-4df8-8271-cb1b22e48574"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("86827f03-fa70-4c54-8396-72e6c03885e2"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("8bc760de-28ee-4ac1-8f36-1791398e2cbb"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("c181243c-f8ab-4f96-b5d7-ac83dbdacc38"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("df8e635c-e1ef-4b50-a5d8-455849220863"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("dfd2dc5d-4f68-4b05-9190-9b22f03d8281"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("f5073484-eb49-43c7-91d7-537e5a06309a"));

//            migrationBuilder.DeleteData(
//                table: "NotificationSetting",
//                keyColumn: "Id",
//                keyValue: new Guid("f57c4bd5-1752-45fb-a54e-d52ee5f62392"));

//            migrationBuilder.DeleteData(
//                table: "Users",
//                keyColumn: "Id",
//                keyValue: new Guid("a7e887a7-4e76-4f96-b0e5-d12ac9503ccc"));

//            migrationBuilder.DeleteData(
//                table: "Users",
//                keyColumn: "Id",
//                keyValue: new Guid("85d80fa1-e21b-4b19-8725-471ee3bcc338"));

//            migrationBuilder.DeleteData(
//                table: "Users",
//                keyColumn: "Id",
//                keyValue: new Guid("c34c7468-09db-493e-b802-c0322f969e3c"));

//            migrationBuilder.DeleteData(
//                table: "UserSettings",
//                keyColumn: "Id",
//                keyValue: new Guid("09673314-6eb4-423e-a93c-34b4126a02cc"));

//            migrationBuilder.DeleteData(
//                table: "UserSettings",
//                keyColumn: "Id",
//                keyValue: new Guid("28d6238e-40ab-4503-b293-bd6867de983b"));

//            migrationBuilder.DeleteData(
//                table: "UserSettings",
//                keyColumn: "Id",
//                keyValue: new Guid("f16a45eb-a764-4d5b-83ce-cb9a2f10f7ce"));

//            migrationBuilder.DeleteData(
//                table: "Users",
//                keyColumn: "Id",
//                keyValue: new Guid("80714178-6faa-4ddf-b9b5-63f1b2932b2e"));

//            migrationBuilder.DeleteData(
//                table: "UserSettings",
//                keyColumn: "Id",
//                keyValue: new Guid("e67b4e66-7e71-4749-933d-027ca0ace096"));
//        }
//    }
//}
