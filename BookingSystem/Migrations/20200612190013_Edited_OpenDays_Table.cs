using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class Edited_OpenDays_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenedDaysFrom",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "OpenedDaysTo",
                table: "OpenDays");

            migrationBuilder.AddColumn<int>(
                name: "OpenedDays",
                table: "OpenDays",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenedDays",
                table: "OpenDays");

            migrationBuilder.AddColumn<int>(
                name: "OpenedDaysFrom",
                table: "OpenDays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpenedDaysTo",
                table: "OpenDays",
                nullable: false,
                defaultValue: 0);
        }
    }
}
