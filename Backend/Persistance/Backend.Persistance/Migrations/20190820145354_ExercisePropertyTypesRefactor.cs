using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class ExercisePropertyTypesRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_BarType_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_Category_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_Equipment_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_Grip_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_Stance_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_Users_Tempo_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_BarPositionId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_BarTypeId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_CategoryId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_GripId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_RangeOfMotionId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_StanceId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_TempoId",
                table: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "ExerciseTypeEquipment");

            migrationBuilder.DropTable(
                name: "ExerciseTypeLoadAccomodation");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_BarPositionId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_BarTypeId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_CategoryId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_GripId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_RangeOfMotionId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_StanceId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_TempoId",
                table: "ExerciseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_BarType_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_Category_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_Equipment_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_Grip_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_Stance_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_Tempo_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "BarPositionId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "BarTypeId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "GripId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "RangeOfMotionId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "StanceId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "TempoId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "BarType_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "Category_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "Equipment_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "ExercisePropertyType",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "Grip_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "Stance_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "Tempo_ApplicationUserId",
                table: "ExerciseProperties");

            migrationBuilder.AddColumn<Guid>(
                name: "ExercisePropertyTypeId",
                table: "ExerciseProperties",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ExercisePropertyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePropertyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisePropertyTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeExerciseProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Show = table.Column<bool>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    ExercisePropertyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeExerciseProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeExerciseProperty_ExerciseProperties_ExercisePropertyId",
                        column: x => x.ExercisePropertyId,
                        principalTable: "ExerciseProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeExerciseProperty_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_ExercisePropertyTypeId",
                table: "ExerciseProperties",
                column: "ExercisePropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePropertyTypes_ApplicationUserId",
                table: "ExercisePropertyTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeExerciseProperty_ExercisePropertyId",
                table: "ExerciseTypeExerciseProperty",
                column: "ExercisePropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeExerciseProperty_ExerciseTypeId",
                table: "ExerciseTypeExerciseProperty",
                column: "ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_ExercisePropertyTypes_ExercisePropertyTypeId",
                table: "ExerciseProperties",
                column: "ExercisePropertyTypeId",
                principalTable: "ExercisePropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseProperties_ExercisePropertyTypes_ExercisePropertyTypeId",
                table: "ExerciseProperties");

            migrationBuilder.DropTable(
                name: "ExercisePropertyTypes");

            migrationBuilder.DropTable(
                name: "ExerciseTypeExerciseProperty");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseProperties_ExercisePropertyTypeId",
                table: "ExerciseProperties");

            migrationBuilder.DropColumn(
                name: "ExercisePropertyTypeId",
                table: "ExerciseProperties");

            migrationBuilder.AddColumn<Guid>(
                name: "BarPositionId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BarTypeId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GripId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RangeOfMotionId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StanceId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TempoId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BarType_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Category_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Equipment_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExercisePropertyType",
                table: "ExerciseProperties",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Grip_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Stance_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Tempo_ApplicationUserId",
                table: "ExerciseProperties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExerciseTypeEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EquipmentId = table.Column<Guid>(nullable: true),
                    ExercisePropertyId = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeEquipment_ExerciseProperties_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "ExerciseProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeEquipment_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeLoadAccomodation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    LoadAccomodationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeLoadAccomodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeLoadAccomodation_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeLoadAccomodation_ExerciseProperties_LoadAccomodationId",
                        column: x => x.LoadAccomodationId,
                        principalTable: "ExerciseProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_BarPositionId",
                table: "ExerciseTypes",
                column: "BarPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_BarTypeId",
                table: "ExerciseTypes",
                column: "BarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_CategoryId",
                table: "ExerciseTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_GripId",
                table: "ExerciseTypes",
                column: "GripId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_RangeOfMotionId",
                table: "ExerciseTypes",
                column: "RangeOfMotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_StanceId",
                table: "ExerciseTypes",
                column: "StanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_TempoId",
                table: "ExerciseTypes",
                column: "TempoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_ApplicationUserId",
                table: "ExerciseProperties",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_BarType_ApplicationUserId",
                table: "ExerciseProperties",
                column: "BarType_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_Category_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Category_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_Equipment_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Equipment_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_Grip_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Grip_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties",
                column: "LoadAccomodation_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties",
                column: "RangeOfMotion_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_Stance_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Stance_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseProperties_Tempo_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Tempo_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeEquipment_EquipmentId",
                table: "ExerciseTypeEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeEquipment_ExerciseTypeId",
                table: "ExerciseTypeEquipment",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeLoadAccomodation_ExerciseTypeId",
                table: "ExerciseTypeLoadAccomodation",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeLoadAccomodation_LoadAccomodationId",
                table: "ExerciseTypeLoadAccomodation",
                column: "LoadAccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_ApplicationUserId",
                table: "ExerciseProperties",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_BarType_ApplicationUserId",
                table: "ExerciseProperties",
                column: "BarType_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_Category_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Category_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_Equipment_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Equipment_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_Grip_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Grip_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_LoadAccomodation_ApplicationUserId",
                table: "ExerciseProperties",
                column: "LoadAccomodation_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_RangeOfMotion_ApplicationUserId",
                table: "ExerciseProperties",
                column: "RangeOfMotion_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_Stance_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Stance_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseProperties_Users_Tempo_ApplicationUserId",
                table: "ExerciseProperties",
                column: "Tempo_ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_BarPositionId",
                table: "ExerciseTypes",
                column: "BarPositionId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_BarTypeId",
                table: "ExerciseTypes",
                column: "BarTypeId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_CategoryId",
                table: "ExerciseTypes",
                column: "CategoryId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_GripId",
                table: "ExerciseTypes",
                column: "GripId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_RangeOfMotionId",
                table: "ExerciseTypes",
                column: "RangeOfMotionId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_StanceId",
                table: "ExerciseTypes",
                column: "StanceId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseProperties_TempoId",
                table: "ExerciseTypes",
                column: "TempoId",
                principalTable: "ExerciseProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
