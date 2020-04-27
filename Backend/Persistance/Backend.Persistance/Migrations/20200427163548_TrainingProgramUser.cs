using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class TrainingProgramUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramUser_Users_ApplicationUserId",
                table: "TrainingProgramUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramUser_TrainingPrograms_TrainingProgramId",
                table: "TrainingProgramUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingProgramUser",
                table: "TrainingProgramUser");

            migrationBuilder.RenameTable(
                name: "TrainingProgramUser",
                newName: "TrainingProgramUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramUser_TrainingProgramId",
                table: "TrainingProgramUsers",
                newName: "IX_TrainingProgramUsers_TrainingProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramUser_ApplicationUserId",
                table: "TrainingProgramUsers",
                newName: "IX_TrainingProgramUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingProgramUsers",
                table: "TrainingProgramUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramUsers_Users_ApplicationUserId",
                table: "TrainingProgramUsers",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramUsers_TrainingPrograms_TrainingProgramId",
                table: "TrainingProgramUsers",
                column: "TrainingProgramId",
                principalTable: "TrainingPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramUsers_Users_ApplicationUserId",
                table: "TrainingProgramUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramUsers_TrainingPrograms_TrainingProgramId",
                table: "TrainingProgramUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingProgramUsers",
                table: "TrainingProgramUsers");

            migrationBuilder.RenameTable(
                name: "TrainingProgramUsers",
                newName: "TrainingProgramUser");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramUsers_TrainingProgramId",
                table: "TrainingProgramUser",
                newName: "IX_TrainingProgramUser_TrainingProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramUsers_ApplicationUserId",
                table: "TrainingProgramUser",
                newName: "IX_TrainingProgramUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingProgramUser",
                table: "TrainingProgramUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramUser_Users_ApplicationUserId",
                table: "TrainingProgramUser",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramUser_TrainingPrograms_TrainingProgramId",
                table: "TrainingProgramUser",
                column: "TrainingProgramId",
                principalTable: "TrainingPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
