using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "MainDashboardId" },
                values: new object[,]
                {
                    { new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65"), new Guid("0faee6ac-1772-4bbe-9990-a7d9a22dd529"), null },
                    { new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583"), new Guid("8d399c00-5654-4a54-9c2c-b44a485c3583"), null },
                    { new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5"), new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4"), null },
                    { new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a"), new Guid("939085da-e515-4422-80eb-7847e7f4eadb"), null }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c15"), "PersonalBestAdded", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c32"), "MediaAdded", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c31"), "NoteAdded", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c30"), "TrainingCreated", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c25"), "PersonalBestAdded", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c24"), "BodyweightAdded", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c23"), "ImportFinished", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c22"), "MediaAdded", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c21"), "NoteAdded", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c20"), "TrainingCreated", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c35"), "PersonalBestAdded", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c33"), "ImportFinished", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c34"), "BodyweightAdded", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c13"), "ImportFinished", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c12"), "MediaAdded", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c11"), "NoteAdded", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c10"), "TrainingCreated", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c05"), "PersonalBestAdded", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c04"), "BodyweightAdded", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c03"), "ImportFinished", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c02"), "MediaAdded", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c01"), "NoteAdded", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c00"), "TrainingCreated", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65") },
                    { new Guid("71691ddc-039f-4606-b614-ff4a19516c14"), "BodyweightAdded", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("0faee6ac-1772-4bbe-9990-a7d9a22dd529"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=8C4FB5&color=ffffff&", new DateTime(2020, 6, 11, 18, 14, 25, 945, DateTimeKind.Utc).AddTicks(5475), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65"), "admin" },
                    { new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=2FE9CA&color=ffffff&", new DateTime(2020, 6, 11, 18, 14, 25, 946, DateTimeKind.Utc).AddTicks(496), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5"), "coach" },
                    { new Guid("939085da-e515-4422-80eb-7847e7f4eadb"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=2689F0&color=ffffff&", new DateTime(2020, 6, 11, 18, 14, 25, 945, DateTimeKind.Utc).AddTicks(9221), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("8d399c00-5654-4a54-9c2c-b44a485c3583"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=4DE6BC&color=ffffff&", new DateTime(2020, 6, 11, 18, 14, 25, 945, DateTimeKind.Utc).AddTicks(8599), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583"), "athlete", new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4") });

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c00"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c01"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c02"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c03"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c04"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c05"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c10"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c11"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c12"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c13"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c14"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c15"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c20"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c21"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c22"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c23"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c24"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c25"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c30"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c31"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c32"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c33"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c34"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("71691ddc-039f-4606-b614-ff4a19516c35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0faee6ac-1772-4bbe-9990-a7d9a22dd529"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d399c00-5654-4a54-9c2c-b44a485c3583"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("939085da-e515-4422-80eb-7847e7f4eadb"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5"));

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingBlockDays_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId",
                principalTable: "TrainingBlockDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}