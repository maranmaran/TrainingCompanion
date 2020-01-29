using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class NonUniqueCode_TrackItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrackItems_Code",
                table: "TrackItems");


            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TrackItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TrackItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_Code",
                table: "TrackItems",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
