using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticDashboard.Migrations
{
    public partial class NoteDateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteDate",
                table: "Notes",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteDate",
                table: "Notes");
        }
    }
}
