using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class PrReps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Reps",
                table: "PBs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SystemCalculated",
                table: "PBs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "PBs");

            migrationBuilder.DropColumn(
                name: "SystemCalculated",
                table: "PBs");
        }
    }
}
