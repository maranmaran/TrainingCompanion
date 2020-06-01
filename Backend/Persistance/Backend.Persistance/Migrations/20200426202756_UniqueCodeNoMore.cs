using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class UniqueCodeNoMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExerciseTypes_Code",
                table: "ExerciseTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_Code",
                table: "ExerciseTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
