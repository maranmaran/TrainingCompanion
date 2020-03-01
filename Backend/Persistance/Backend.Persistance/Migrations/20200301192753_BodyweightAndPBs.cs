using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class BodyweightAndPBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMax");


            migrationBuilder.CreateTable(
                name: "Bodyweights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodyweights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bodyweights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    DateAchieved = table.Column<DateTime>(nullable: false),
                    Bodyweight = table.Column<double>(nullable: true),
                    WilksScore = table.Column<double>(nullable: false),
                    IpfPoints = table.Column<double>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PBs_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodyweights_UserId",
                table: "Bodyweights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PBs_ExerciseTypeId",
                table: "PBs",
                column: "ExerciseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bodyweights");

            migrationBuilder.DropTable(
                name: "PBs");

            migrationBuilder.CreateTable(
                name: "ExerciseMax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAchieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExerciseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpfPoints = table.Column<double>(type: "float", nullable: false),
                    Max = table.Column<double>(type: "float", nullable: false),
                    WilksScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseMax_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMax_ExerciseTypeId",
                table: "ExerciseMax",
                column: "ExerciseTypeId");
        }
    }
}
