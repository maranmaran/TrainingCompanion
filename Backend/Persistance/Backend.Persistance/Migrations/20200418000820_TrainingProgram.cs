using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class TrainingProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<Guid>(
                name: "TrainingBlockDayId",
                table: "Trainings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageFtpFilePath = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrainingProgramId = table.Column<Guid>(nullable: false),
                    DurationInDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBlocks_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    EndedOn = table.Column<DateTime>(nullable: true),
                    TrainingProgramId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgramUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingProgramUser_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingProgramUser_TrainingPrograms_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "TrainingPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingBlockDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RestDay = table.Column<bool>(nullable: false),
                    TrainingBlockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBlockDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBlockDays_TrainingBlocks_TrainingBlockId",
                        column: x => x.TrainingBlockId,
                        principalTable: "TrainingBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingBlockDayId",
                table: "Trainings",
                column: "TrainingBlockDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBlockDays_TrainingBlockId",
                table: "TrainingBlockDays",
                column: "TrainingBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBlocks_TrainingProgramId",
                table: "TrainingBlocks",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_CreatorId",
                table: "TrainingPrograms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramUser_ApplicationUserId",
                table: "TrainingProgramUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramUser_TrainingProgramId",
                table: "TrainingProgramUser",
                column: "TrainingProgramId");

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

            migrationBuilder.DropTable(
                name: "TrainingBlockDays");

            migrationBuilder.DropTable(
                name: "TrainingProgramUser");

            migrationBuilder.DropTable(
                name: "TrainingBlocks");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingBlockDayId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingBlockDayId",
                table: "Trainings");
        }
    }
}
