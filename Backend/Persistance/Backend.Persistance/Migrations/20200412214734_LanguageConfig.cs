using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class LanguageConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "UserSettings",
                maxLength: 2,
                nullable: true,
                defaultValue: "en",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0faee6ac-1772-4bbe-9990-a7d9a22dd529"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn" },
                values: new object[] { "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=1FDCC2&color=ffffff&", new DateTime(2020, 4, 12, 21, 47, 33, 800, DateTimeKind.Utc).AddTicks(3629) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d399c00-5654-4a54-9c2c-b44a485c3583"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn" },
                values: new object[] { "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=EC95C1&color=ffffff&", new DateTime(2020, 4, 12, 21, 47, 33, 800, DateTimeKind.Utc).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn" },
                values: new object[] { "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=60A1D7&color=ffffff&", new DateTime(2020, 4, 12, 21, 47, 33, 801, DateTimeKind.Utc).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("939085da-e515-4422-80eb-7847e7f4eadb"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn" },
                values: new object[] { "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=17148C&color=ffffff&", new DateTime(2020, 4, 12, 21, 47, 33, 801, DateTimeKind.Utc).AddTicks(725) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true,
                oldDefaultValue: "en");

            migrationBuilder.UpdateData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("051fde35-1f15-4ffe-81d0-e67e2459a6c5"),
                columns: new[] { "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { "Rpe", "Light", "Imperial" });

            migrationBuilder.UpdateData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("0d528a91-fbbe-4a02-924a-792344bbbd65"),
                columns: new[] { "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { "Rpe", "Light", "Imperial" });

            migrationBuilder.UpdateData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("46bd253c-a630-4759-a2a5-a4ec7497c88a"),
                columns: new[] { "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { "Rpe", "Light", "Imperial" });

            migrationBuilder.UpdateData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("8d399c00-5684-4a54-9c2c-b44a485c3583"),
                columns: new[] { "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { "Rpe", "Light", "Imperial" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0faee6ac-1772-4bbe-9990-a7d9a22dd529"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn", "Gender" },
                values: new object[] { "User", null, new DateTime(2020, 4, 12, 21, 28, 38, 822, DateTimeKind.Utc).AddTicks(1187), "Male" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d399c00-5654-4a54-9c2c-b44a485c3583"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn", "Gender" },
                values: new object[] { "User", null, new DateTime(2020, 4, 12, 21, 28, 38, 822, DateTimeKind.Utc).AddTicks(4728), "Male" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa67c815-486e-4e9d-89dd-3156376ac9b4"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn", "Gender" },
                values: new object[] { "User", null, new DateTime(2020, 4, 12, 21, 28, 38, 822, DateTimeKind.Utc).AddTicks(7426), "Male" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("939085da-e515-4422-80eb-7847e7f4eadb"),
                columns: new[] { "AccountType", "Avatar", "CreatedOn", "Gender" },
                values: new object[] { "User", null, new DateTime(2020, 4, 12, 21, 28, 38, 822, DateTimeKind.Utc).AddTicks(5570), "Male" });
        }
    }
}
