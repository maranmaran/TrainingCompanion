using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class TrackChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("00a528c4-90fe-4587-912e-0177cf846762"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0b055f93-d06d-4d4b-a115-93c931a13b87"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("21a58446-53d3-4dd0-8a36-6c7183f5d1d0"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2a10a49f-3606-436f-bcda-aafe612639e7"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("35834be9-0068-497a-9feb-20cc1d58c20e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("422aa37a-a5f5-41ed-b998-0ccb1bd17a7b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("4b889df4-041d-407c-860f-97fe1ab4a271"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9241c3d3-c01d-48bd-b2fc-da10e5729567"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b6049297-2f8f-4791-b2dc-5bba0ee8a62b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c04ff201-1292-4180-9bc0-ae0e7d59cf1e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c2833173-8e24-45e0-b2b1-62fc36336eed"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d1caeb02-d2a1-4af7-b7bb-a38798cab71e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("dae2346c-165a-44b7-ad5a-5a5dcdd5aed1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ef75ce44-4f32-4e62-86d3-97279697dcb1"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f1c75231-cc3e-4066-aa1c-fd745fe649b6"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f68ad620-652e-4455-abdb-30425f41d00d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7dc98fc-8a2e-4c07-bb3f-fcb3008fce4b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef82fff2-21a7-483f-b071-d6cd47bc0130"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4a02f6c-8cb2-4393-9514-33de34155770"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("6a763299-574a-4d44-aa79-62cffd379a72"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0998796a-b6de-4bb2-b07d-60c8c0009a9d"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: "97f56b61-da8b-4ce6-bc69-8a954a628826",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldDefaultValue: "3a969157-dc5a-4e68-ab98-735b1f6b2255");

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[,]
                {
                    { new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3"), new Guid("2632979f-2396-495e-a3f3-66a91250a15d") },
                    { new Guid("d1030967-f427-40e7-b5f0-f3993c74a965"), new Guid("44b8ba52-10d8-4c8f-893e-73fcd0040038") },
                    { new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be"), new Guid("9e58e297-37c8-45b6-8b41-c5d1812a2758") },
                    { new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73"), new Guid("6260d78a-2cb5-4e0e-b098-4e9a8fc3d4de") }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("1c9b0cf0-203b-470e-babb-d287cec50aaf"), "ImportFinished", new Guid("d1030967-f427-40e7-b5f0-f3993c74a965") },
                    { new Guid("a966a0cb-9920-4d5f-ad6f-8f3e611578fd"), "TrainingCreated", new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73") },
                    { new Guid("2049f10d-aa37-4783-aedf-2f6c523fd0da"), "ImportFinished", new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be") },
                    { new Guid("9d0e3f90-fefb-4d84-8083-9704ecb24d8e"), "MediaAdded", new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be") },
                    { new Guid("3cee53a9-e011-48f0-b1d1-b5cc4531d1be"), "NoteAdded", new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be") },
                    { new Guid("e37800c5-4c2b-4e63-9c75-cf4d5ee18a4b"), "TrainingCreated", new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be") },
                    { new Guid("16950a1d-16ac-46b3-8717-7ed47c99993d"), "ImportFinished", new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73") },
                    { new Guid("ee2ce832-91bf-49e7-913a-8647c5bf4567"), "NoteAdded", new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73") },
                    { new Guid("a21379dd-1df6-40d5-8ad8-922386bab730"), "MediaAdded", new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73") },
                    { new Guid("700d26f7-7a4b-4248-907c-b546a087c924"), "NoteAdded", new Guid("d1030967-f427-40e7-b5f0-f3993c74a965") },
                    { new Guid("2c3f2192-a887-4c85-9a34-6613ba453c87"), "TrainingCreated", new Guid("d1030967-f427-40e7-b5f0-f3993c74a965") },
                    { new Guid("444daff5-dd31-4b85-8bd3-9040574ffc44"), "ImportFinished", new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3") },
                    { new Guid("6fc5cfcb-abb4-40af-894d-9c5881102836"), "MediaAdded", new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3") },
                    { new Guid("8d19b7fe-c978-433d-964f-ab352060f5a6"), "NoteAdded", new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3") },
                    { new Guid("5e410850-912e-49a8-b72a-b761852694aa"), "TrainingCreated", new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3") },
                    { new Guid("af80e200-5438-4b8d-9417-0ae4d0633a5f"), "MediaAdded", new Guid("d1030967-f427-40e7-b5f0-f3993c74a965") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("2632979f-2396-495e-a3f3-66a91250a15d"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=5122CF&color=ffffff&", new DateTime(2020, 1, 21, 21, 25, 50, 961, DateTimeKind.Utc).AddTicks(9636), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3"), "admin" },
                    { new Guid("9e58e297-37c8-45b6-8b41-c5d1812a2758"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=0ED5A5&color=ffffff&", new DateTime(2020, 1, 21, 21, 25, 50, 962, DateTimeKind.Utc).AddTicks(5624), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be"), "coach" },
                    { new Guid("6260d78a-2cb5-4e0e-b098-4e9a8fc3d4de"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=BCAD63&color=ffffff&", new DateTime(2020, 1, 21, 21, 25, 50, 962, DateTimeKind.Utc).AddTicks(4101), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("44b8ba52-10d8-4c8f-893e-73fcd0040038"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=A05339&color=ffffff&", new DateTime(2020, 1, 21, 21, 25, 50, 962, DateTimeKind.Utc).AddTicks(3409), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("d1030967-f427-40e7-b5f0-f3993c74a965"), "athlete", new Guid("9e58e297-37c8-45b6-8b41-c5d1812a2758") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("16950a1d-16ac-46b3-8717-7ed47c99993d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("1c9b0cf0-203b-470e-babb-d287cec50aaf"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2049f10d-aa37-4783-aedf-2f6c523fd0da"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2c3f2192-a887-4c85-9a34-6613ba453c87"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3cee53a9-e011-48f0-b1d1-b5cc4531d1be"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("444daff5-dd31-4b85-8bd3-9040574ffc44"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5e410850-912e-49a8-b72a-b761852694aa"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6fc5cfcb-abb4-40af-894d-9c5881102836"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("700d26f7-7a4b-4248-907c-b546a087c924"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8d19b7fe-c978-433d-964f-ab352060f5a6"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9d0e3f90-fefb-4d84-8083-9704ecb24d8e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a21379dd-1df6-40d5-8ad8-922386bab730"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a966a0cb-9920-4d5f-ad6f-8f3e611578fd"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("af80e200-5438-4b8d-9417-0ae4d0633a5f"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e37800c5-4c2b-4e63-9c75-cf4d5ee18a4b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ee2ce832-91bf-49e7-913a-8647c5bf4567"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2632979f-2396-495e-a3f3-66a91250a15d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44b8ba52-10d8-4c8f-893e-73fcd0040038"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6260d78a-2cb5-4e0e-b098-4e9a8fc3d4de"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("156b4b50-c7d2-4db2-88a4-d9ff0d3cf7a3"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("cf15fd6b-b70e-481b-8209-60f5d134cd73"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d1030967-f427-40e7-b5f0-f3993c74a965"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e58e297-37c8-45b6-8b41-c5d1812a2758"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("c24920fc-fd9e-405a-80e3-f6a855ceb5be"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExerciseTypes",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "3a969157-dc5a-4e68-ab98-735b1f6b2255",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "97f56b61-da8b-4ce6-bc69-8a954a628826");

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[,]
                {
                    { new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8"), new Guid("a7dc98fc-8a2e-4c07-bb3f-fcb3008fce4b"), "Rpe", "Light", "Imperial" },
                    { new Guid("6a763299-574a-4d44-aa79-62cffd379a72"), new Guid("ef82fff2-21a7-483f-b071-d6cd47bc0130"), "Rpe", "Light", "Imperial" },
                    { new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f"), new Guid("0998796a-b6de-4bb2-b07d-60c8c0009a9d"), "Rpe", "Light", "Imperial" },
                    { new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29"), new Guid("c4a02f6c-8cb2-4393-9514-33de34155770"), "Rpe", "Light", "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("f1c75231-cc3e-4066-aa1c-fd745fe649b6"), "ImportFinished", new Guid("6a763299-574a-4d44-aa79-62cffd379a72") },
                    { new Guid("b6049297-2f8f-4791-b2dc-5bba0ee8a62b"), "TrainingCreated", new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29") },
                    { new Guid("c2833173-8e24-45e0-b2b1-62fc36336eed"), "ImportFinished", new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f") },
                    { new Guid("f68ad620-652e-4455-abdb-30425f41d00d"), "MediaAdded", new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f") },
                    { new Guid("4b889df4-041d-407c-860f-97fe1ab4a271"), "NoteAdded", new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f") },
                    { new Guid("35834be9-0068-497a-9feb-20cc1d58c20e"), "TrainingCreated", new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f") },
                    { new Guid("d1caeb02-d2a1-4af7-b7bb-a38798cab71e"), "ImportFinished", new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29") },
                    { new Guid("00a528c4-90fe-4587-912e-0177cf846762"), "NoteAdded", new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29") },
                    { new Guid("dae2346c-165a-44b7-ad5a-5a5dcdd5aed1"), "MediaAdded", new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29") },
                    { new Guid("2a10a49f-3606-436f-bcda-aafe612639e7"), "NoteAdded", new Guid("6a763299-574a-4d44-aa79-62cffd379a72") },
                    { new Guid("422aa37a-a5f5-41ed-b998-0ccb1bd17a7b"), "TrainingCreated", new Guid("6a763299-574a-4d44-aa79-62cffd379a72") },
                    { new Guid("c04ff201-1292-4180-9bc0-ae0e7d59cf1e"), "ImportFinished", new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8") },
                    { new Guid("0b055f93-d06d-4d4b-a115-93c931a13b87"), "MediaAdded", new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8") },
                    { new Guid("ef75ce44-4f32-4e62-86d3-97279697dcb1"), "NoteAdded", new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8") },
                    { new Guid("21a58446-53d3-4dd0-8a36-6c7183f5d1d0"), "TrainingCreated", new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8") },
                    { new Guid("9241c3d3-c01d-48bd-b2fc-da10e5729567"), "MediaAdded", new Guid("6a763299-574a-4d44-aa79-62cffd379a72") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("a7dc98fc-8a2e-4c07-bb3f-fcb3008fce4b"), "User", null, new DateTime(2020, 1, 21, 21, 23, 10, 805, DateTimeKind.Utc).AddTicks(8345), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("1c418784-04fe-48bc-8323-6ef80fbb77d8"), "admin" },
                    { new Guid("0998796a-b6de-4bb2-b07d-60c8c0009a9d"), "User", null, new DateTime(2020, 1, 21, 21, 23, 10, 806, DateTimeKind.Utc).AddTicks(4309), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("3433071f-78d1-4b8d-af1e-9ce44020578f"), "coach" },
                    { new Guid("c4a02f6c-8cb2-4393-9514-33de34155770"), "User", null, new DateTime(2020, 1, 21, 21, 23, 10, 806, DateTimeKind.Utc).AddTicks(2848), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("17e26673-d3fe-4a96-b7fb-bd35b7cfcc29"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("ef82fff2-21a7-483f-b071-d6cd47bc0130"), "User", null, new DateTime(2020, 1, 21, 21, 23, 10, 806, DateTimeKind.Utc).AddTicks(2192), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("6a763299-574a-4d44-aa79-62cffd379a72"), "athlete", new Guid("0998796a-b6de-4bb2-b07d-60c8c0009a9d") });
        }
    }
}
