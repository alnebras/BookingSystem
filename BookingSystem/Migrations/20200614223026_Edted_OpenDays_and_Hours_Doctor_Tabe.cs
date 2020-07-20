using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class Edted_OpenDays_and_Hours_Doctor_Tabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FrayDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HourFrom",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HourTo",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SatarDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SunDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TharuseDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuseDay",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinsedrDay",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrayDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HourFrom",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HourTo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "MonDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SatarDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SunDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TharuseDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TuseDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "WinsedrDay",
                table: "Doctors");
        }
    }
}
