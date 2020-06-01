using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class SetPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxUsedForPercentage",
                table: "Sets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxUsedForPercentage",
                table: "Sets");
        }
    }
}
