using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class Edited_OpenDays2_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Friyday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Monday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Satarday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sunday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thursday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tuseday",
                table: "OpenDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wnesdday",
                table: "OpenDays",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friyday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Satarday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Tuseday",
                table: "OpenDays");

            migrationBuilder.DropColumn(
                name: "Wnesdday",
                table: "OpenDays");
        }
    }
}
