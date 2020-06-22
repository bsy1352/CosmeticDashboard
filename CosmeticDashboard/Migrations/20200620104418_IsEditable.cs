using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticDashboard.Migrations
{
    public partial class IsEditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEditable",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEditable",
                table: "Users");
        }
    }
}
