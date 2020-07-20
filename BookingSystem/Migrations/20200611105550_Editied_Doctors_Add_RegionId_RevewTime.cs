using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class Editied_Doctors_Add_RegionId_RevewTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Doctors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewTime",
                table: "Doctors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RegionId",
                table: "Doctors",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Regions_RegionId",
                table: "Doctors",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Regions_RegionId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RegionId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ReviewTime",
                table: "Doctors");
        }
    }
}
