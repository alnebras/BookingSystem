using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class Editied_Add_AreaId_Doctors_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "Doctors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AreaId",
                table: "Doctors",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Areas_AreaId",
                table: "Doctors",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Areas_AreaId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AreaId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Doctors");
        }
    }
}
