using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class RemoveTrackItemParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackItemParams");


            migrationBuilder.AddColumn<string>(
                name: "JsonParams",
                table: "TrackItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonParams",
                table: "TrackItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ParamsId",
                table: "TrackItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrackItemParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JsonParams = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackItemParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackItemParams_TrackItems_TrackItemId",
                        column: x => x.TrackItemId,
                        principalTable: "TrackItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackItemParams_TrackItemId",
                table: "TrackItemParams",
                column: "TrackItemId",
                unique: true,
                filter: "[TrackItemId] IS NOT NULL");
        }
    }
}
