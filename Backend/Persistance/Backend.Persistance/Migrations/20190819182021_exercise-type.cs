using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class exercisetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_BarPositions_BarPositionId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_BarTypes_BarTypeId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_ExerciseCategories_CategoryId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Grips_GripId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_RangeOfMotions_RangeOfMotionId",
                table: "ExerciseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypes_Stances_StanceId",
                table: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "BarPositions");

            migrationBuilder.DropTable(
                name: "BarTypes");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "ExerciseEquipments");

            migrationBuilder.DropTable(
                name: "Grips");

            migrationBuilder.DropTable(
                name: "LoadAccomodations");

            migrationBuilder.DropTable(
                name: "RangeOfMotions");

            migrationBuilder.DropTable(
                name: "Stances");

            migrationBuilder.DropTable(
                name: "Tempos");

            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "Coach");

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresWeight",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresTime",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresSets",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresReps",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresBodyweight",
                table: "ExerciseTypes",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<Guid>(
                name: "TempoId",
                table: "ExerciseTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ExerciseProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExercisePropertyType = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    BarType_ApplicationUserId = table.Column<Guid>(nullable: true),
                    Category_ApplicationUserId = table.Column<Guid>(nullable: true),
                    Equipment_ApplicationUserId = table.Column<Guid>(nullable: true),
                    Grip_ApplicationUserId = table.Column<Guid>(nullable: true),
                    LoadAccomodation_ApplicationUserId = table.Column<Guid>(nullable: true),
                    RangeOfMotion_ApplicationUserId = table.Column<Guid>(nullable: true),
                    Stance_ApplicationUserId = table.Column<Guid>(nullable: true),
                    Tempo_ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_BarType_ApplicationUserId",
                        column: x => x.BarType_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_Category_ApplicationUserId",
                        column: x => x.Category_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_Equipment_ApplicationUserId",
                        column: x => x.Equipment_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_Grip_ApplicationUserId",
                        column: x => x.Grip_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_LoadAccomodation_ApplicationUserId",
                        column: x => x.LoadAccomodation_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_RangeOfMotion_ApplicationUserId",
                        column: x => x.RangeOfMotion_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_Stance_ApplicationUserId",
                        column: x => x.Stance_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseProperties_Users_Tempo_ApplicationUserId",
                        column: x => x.Tempo_ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    ExercisePropertyId = table.Column<Guid>(nullable: false),
                    EquipmentId = table.Column<Guid>(nullable: true)
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
                name: "IX_ExerciseTypes_TempoId",
                table: "ExerciseTypes",
                column: "TempoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "ExerciseProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_TempoId",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "TempoId",
                table: "ExerciseTypes");

            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Users",
                nullable: false,
                defaultValue: "Coach",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresWeight",
                table: "ExerciseTypes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresTime",
                table: "ExerciseTypes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresSets",
                table: "ExerciseTypes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresReps",
                table: "ExerciseTypes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresBodyweight",
                table: "ExerciseTypes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ExerciseTypes",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.CreateTable(
                name: "BarPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarPositions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseCategories_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grips",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grips_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoadAccomodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadAccomodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadAccomodations_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadAccomodations_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RangeOfMotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeOfMotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangeOfMotions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stances_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tempos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    ExerciseTypeId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tempos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tempos_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tempos_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarPositions_ApplicationUserId",
                table: "BarPositions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BarTypes_ApplicationUserId",
                table: "BarTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_ApplicationUserId",
                table: "ExerciseCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipments_ApplicationUserId",
                table: "ExerciseEquipments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipments_ExerciseTypeId",
                table: "ExerciseEquipments",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grips_ApplicationUserId",
                table: "Grips",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadAccomodations_ApplicationUserId",
                table: "LoadAccomodations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadAccomodations_ExerciseTypeId",
                table: "LoadAccomodations",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RangeOfMotions_ApplicationUserId",
                table: "RangeOfMotions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stances_ApplicationUserId",
                table: "Stances",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tempos_ApplicationUserId",
                table: "Tempos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tempos_ExerciseTypeId",
                table: "Tempos",
                column: "ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_BarPositions_BarPositionId",
                table: "ExerciseTypes",
                column: "BarPositionId",
                principalTable: "BarPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_BarTypes_BarTypeId",
                table: "ExerciseTypes",
                column: "BarTypeId",
                principalTable: "BarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_ExerciseCategories_CategoryId",
                table: "ExerciseTypes",
                column: "CategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Grips_GripId",
                table: "ExerciseTypes",
                column: "GripId",
                principalTable: "Grips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_RangeOfMotions_RangeOfMotionId",
                table: "ExerciseTypes",
                column: "RangeOfMotionId",
                principalTable: "RangeOfMotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypes_Stances_StanceId",
                table: "ExerciseTypes",
                column: "StanceId",
                principalTable: "Stances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
