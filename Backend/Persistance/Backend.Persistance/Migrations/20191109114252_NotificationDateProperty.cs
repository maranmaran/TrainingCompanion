using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class NotificationDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_SenderId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SenderId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "Notifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Notifications",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId1",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId1",
                table: "Notifications",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_SenderId1",
                table: "Notifications",
                column: "SenderId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
