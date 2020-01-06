using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class NotificationUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_SenderId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("030f0315-8757-4a3b-aafb-965c890e209b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("15d86dcc-1c9b-4f4a-86bb-21b922d840af"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("1f6636c5-dafd-4a29-883f-78cd0cc0ce41"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("650fec1c-81e2-4f5a-9fd5-479b0f3bd224"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6ad3e660-e4f3-4f0b-a7bb-0ac8495accc6"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("7c712fa2-9e01-45ba-8fef-b84ed29b6863"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8b960d40-819e-4549-a124-43cf19f7d70a"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9d2743ac-caa5-4136-ac93-8882b4524ddb"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9f3266f5-8dee-4588-a5a5-cb9a2c9fe06f"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("af5869ce-5a7f-4c2f-898f-395509f83a8e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c4b776cc-8cc3-4af5-b646-f71999d22739"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e01acaf2-3bca-4f5f-bbf0-bfe514289437"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e6c90e2e-4eef-4b53-aa67-8a43135727d6"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ea772ba6-0981-4098-9a9b-b69a143c9716"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fb9df8e7-6a10-46ca-804f-63affcb6fd33"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ffbaa8a8-082c-4e6f-8736-c3816a9fc1dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4a32c8c2-2218-4715-8375-9e0a09963ea6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ef3738e-fd2b-441c-a89d-bfee834cbfce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf38fc90-8153-4590-9934-65d07452b3e5"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9cd9dfe6-ccda-4e9f-9772-b2219be75207"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d184b3b4-f384-4963-9daa-96c21d73def0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SenderId",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: "414f1d21-3b8d-408f-829e-e3d78b7d01ab",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "e5bb86dd-99a1-46d5-80fd-77d0d3551a32");

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[,]
                {
                    { new Guid("5b1666a6-372e-4527-b278-33288ecdfb43"), new Guid("4110efb7-0fc0-4961-955e-22b425eaaaa2") },
                    { new Guid("d5403845-f7ee-497a-a310-b28701e37c13"), new Guid("8bf483d4-609a-45aa-88ed-81f1a3d56da6") },
                    { new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b"), new Guid("c14cf188-78fb-42fd-83aa-12569c09ec4e") },
                    { new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4"), new Guid("c1fb39ed-8d9d-4973-8872-a2af5e35abb5") }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("70afb16a-7026-4027-8494-86d49fe469fb"), "ImportFinished", new Guid("d5403845-f7ee-497a-a310-b28701e37c13") },
                    { new Guid("f508d017-2d0e-498c-b44e-c685909024c6"), "TrainingCreated", new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4") },
                    { new Guid("70ce5d16-69b3-44d6-8299-603646b1042e"), "ImportFinished", new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b") },
                    { new Guid("acee2efb-c21f-4d27-96de-fa2d7814fb2e"), "MediaAdded", new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b") },
                    { new Guid("b6f69f6b-a708-4ee6-af2d-c93f8be50a62"), "NoteAdded", new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b") },
                    { new Guid("d8463468-ba1b-4a99-8794-f9eb62a817b5"), "TrainingCreated", new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b") },
                    { new Guid("c89d65ff-a5e9-43f5-9dae-3818f8459666"), "ImportFinished", new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4") },
                    { new Guid("dc351de6-9229-4cb9-bda3-6adeeaefd5db"), "NoteAdded", new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4") },
                    { new Guid("ed55e3c2-62f7-43a3-bb58-c7ed385b09b9"), "MediaAdded", new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4") },
                    { new Guid("17fda3a2-68d0-4f82-af4d-c083555a29d4"), "NoteAdded", new Guid("d5403845-f7ee-497a-a310-b28701e37c13") },
                    { new Guid("b508855c-be6a-48f3-a9da-398839f0bb30"), "TrainingCreated", new Guid("d5403845-f7ee-497a-a310-b28701e37c13") },
                    { new Guid("4f21361b-c449-4faf-81d1-46ec8baf969e"), "ImportFinished", new Guid("5b1666a6-372e-4527-b278-33288ecdfb43") },
                    { new Guid("670c0faf-9d9f-44fe-a699-0236bc8dc9b5"), "MediaAdded", new Guid("5b1666a6-372e-4527-b278-33288ecdfb43") },
                    { new Guid("b2d0bf66-60e6-481a-b0be-5db8c19d77c0"), "NoteAdded", new Guid("5b1666a6-372e-4527-b278-33288ecdfb43") },
                    { new Guid("7f605f49-ac96-4ec1-821e-f30b6297a548"), "TrainingCreated", new Guid("5b1666a6-372e-4527-b278-33288ecdfb43") },
                    { new Guid("d5e473cd-5a32-4b42-bf97-b218b8b6267b"), "MediaAdded", new Guid("d5403845-f7ee-497a-a310-b28701e37c13") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("4110efb7-0fc0-4961-955e-22b425eaaaa2"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=C14121&color=ffffff&", new DateTime(2020, 1, 6, 17, 27, 33, 640, DateTimeKind.Utc).AddTicks(4483), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("5b1666a6-372e-4527-b278-33288ecdfb43"), "admin" },
                    { new Guid("c14cf188-78fb-42fd-83aa-12569c09ec4e"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=147CC4&color=ffffff&", new DateTime(2020, 1, 6, 17, 27, 33, 641, DateTimeKind.Utc).AddTicks(1122), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b"), "coach" },
                    { new Guid("c1fb39ed-8d9d-4973-8872-a2af5e35abb5"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=1E5B69&color=ffffff&", new DateTime(2020, 1, 6, 17, 27, 33, 640, DateTimeKind.Utc).AddTicks(9587), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("8bf483d4-609a-45aa-88ed-81f1a3d56da6"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=01C1F7&color=ffffff&", new DateTime(2020, 1, 6, 17, 27, 33, 640, DateTimeKind.Utc).AddTicks(8744), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("d5403845-f7ee-497a-a310-b28701e37c13"), "athlete", new Guid("c14cf188-78fb-42fd-83aa-12569c09ec4e") });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_SenderId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("17fda3a2-68d0-4f82-af4d-c083555a29d4"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("4f21361b-c449-4faf-81d1-46ec8baf969e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("670c0faf-9d9f-44fe-a699-0236bc8dc9b5"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("70afb16a-7026-4027-8494-86d49fe469fb"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("70ce5d16-69b3-44d6-8299-603646b1042e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("7f605f49-ac96-4ec1-821e-f30b6297a548"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("acee2efb-c21f-4d27-96de-fa2d7814fb2e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b2d0bf66-60e6-481a-b0be-5db8c19d77c0"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b508855c-be6a-48f3-a9da-398839f0bb30"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b6f69f6b-a708-4ee6-af2d-c93f8be50a62"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c89d65ff-a5e9-43f5-9dae-3818f8459666"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d5e473cd-5a32-4b42-bf97-b218b8b6267b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d8463468-ba1b-4a99-8794-f9eb62a817b5"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("dc351de6-9229-4cb9-bda3-6adeeaefd5db"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ed55e3c2-62f7-43a3-bb58-c7ed385b09b9"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f508d017-2d0e-498c-b44e-c685909024c6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4110efb7-0fc0-4961-955e-22b425eaaaa2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8bf483d4-609a-45aa-88ed-81f1a3d56da6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c1fb39ed-8d9d-4973-8872-a2af5e35abb5"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("5b1666a6-372e-4527-b278-33288ecdfb43"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("7c05fd95-485d-46fd-8b42-e1800ebf6af4"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d5403845-f7ee-497a-a310-b28701e37c13"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c14cf188-78fb-42fd-83aa-12569c09ec4e"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("a651de87-5a6d-4d8b-b6c2-e4f5169ce60b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SenderId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExerciseTypes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "e5bb86dd-99a1-46d5-80fd-77d0d3551a32",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "414f1d21-3b8d-408f-829e-e3d78b7d01ab");

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[,]
                {
                    { new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1"), new Guid("4a32c8c2-2218-4715-8375-9e0a09963ea6"), "Rpe", "Light", "Imperial" },
                    { new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2"), new Guid("9ef3738e-fd2b-441c-a89d-bfee834cbfce"), "Rpe", "Light", "Imperial" },
                    { new Guid("d184b3b4-f384-4963-9daa-96c21d73def0"), new Guid("9cd9dfe6-ccda-4e9f-9772-b2219be75207"), "Rpe", "Light", "Imperial" },
                    { new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15"), new Guid("bf38fc90-8153-4590-9934-65d07452b3e5"), "Rpe", "Light", "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[,]
                {
                    { new Guid("7c712fa2-9e01-45ba-8fef-b84ed29b6863"), "ImportFinished", new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2") },
                    { new Guid("fb9df8e7-6a10-46ca-804f-63affcb6fd33"), "TrainingCreated", new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15") },
                    { new Guid("9f3266f5-8dee-4588-a5a5-cb9a2c9fe06f"), "ImportFinished", new Guid("d184b3b4-f384-4963-9daa-96c21d73def0") },
                    { new Guid("e6c90e2e-4eef-4b53-aa67-8a43135727d6"), "MediaAdded", new Guid("d184b3b4-f384-4963-9daa-96c21d73def0") },
                    { new Guid("8b960d40-819e-4549-a124-43cf19f7d70a"), "NoteAdded", new Guid("d184b3b4-f384-4963-9daa-96c21d73def0") },
                    { new Guid("c4b776cc-8cc3-4af5-b646-f71999d22739"), "TrainingCreated", new Guid("d184b3b4-f384-4963-9daa-96c21d73def0") },
                    { new Guid("af5869ce-5a7f-4c2f-898f-395509f83a8e"), "ImportFinished", new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15") },
                    { new Guid("ffbaa8a8-082c-4e6f-8736-c3816a9fc1dc"), "NoteAdded", new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15") },
                    { new Guid("e01acaf2-3bca-4f5f-bbf0-bfe514289437"), "MediaAdded", new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15") },
                    { new Guid("ea772ba6-0981-4098-9a9b-b69a143c9716"), "NoteAdded", new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2") },
                    { new Guid("9d2743ac-caa5-4136-ac93-8882b4524ddb"), "TrainingCreated", new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2") },
                    { new Guid("030f0315-8757-4a3b-aafb-965c890e209b"), "ImportFinished", new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1") },
                    { new Guid("650fec1c-81e2-4f5a-9fd5-479b0f3bd224"), "MediaAdded", new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1") },
                    { new Guid("6ad3e660-e4f3-4f0b-a7bb-0ac8495accc6"), "NoteAdded", new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1") },
                    { new Guid("1f6636c5-dafd-4a29-883f-78cd0cc0ce41"), "TrainingCreated", new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1") },
                    { new Guid("15d86dcc-1c9b-4f4a-86bb-21b922d840af"), "MediaAdded", new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[,]
                {
                    { new Guid("4a32c8c2-2218-4715-8375-9e0a09963ea6"), "User", null, new DateTime(2020, 1, 6, 17, 2, 13, 998, DateTimeKind.Utc).AddTicks(6450), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("8c75cab8-75ff-4daf-ae01-e815963816b1"), "admin" },
                    { new Guid("9cd9dfe6-ccda-4e9f-9772-b2219be75207"), "User", null, new DateTime(2020, 1, 6, 17, 2, 13, 999, DateTimeKind.Utc).AddTicks(2311), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("d184b3b4-f384-4963-9daa-96c21d73def0"), "coach" },
                    { new Guid("bf38fc90-8153-4590-9934-65d07452b3e5"), "User", null, new DateTime(2020, 1, 6, 17, 2, 13, 999, DateTimeKind.Utc).AddTicks(455), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("e8be6fff-0e04-4646-a4ef-5cd606655e15"), "soloathlete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("9ef3738e-fd2b-441c-a89d-bfee834cbfce"), "User", null, new DateTime(2020, 1, 6, 17, 2, 13, 998, DateTimeKind.Utc).AddTicks(9736), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("94cbd4bc-c968-47fa-8c0c-e1c3666c21a2"), "athlete", new Guid("9cd9dfe6-ccda-4e9f-9772-b2219be75207") });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
