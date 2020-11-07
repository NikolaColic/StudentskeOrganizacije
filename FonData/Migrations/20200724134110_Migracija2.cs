using Microsoft.EntityFrameworkCore.Migrations;

namespace FonData.Migrations
{
    public partial class Migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sektor_Student_StudentId",
                table: "Sektor");

            migrationBuilder.DropIndex(
                name: "IX_Sektor_StudentId",
                table: "Sektor");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Sektor");

            migrationBuilder.AddColumn<int>(
                name: "SektorId",
                table: "ClanOrganizacije",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClanOrganizacije_SektorId",
                table: "ClanOrganizacije",
                column: "SektorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClanOrganizacije_Sektor_SektorId",
                table: "ClanOrganizacije",
                column: "SektorId",
                principalTable: "Sektor",
                principalColumn: "SektorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanOrganizacije_Sektor_SektorId",
                table: "ClanOrganizacije");

            migrationBuilder.DropIndex(
                name: "IX_ClanOrganizacije_SektorId",
                table: "ClanOrganizacije");

            migrationBuilder.DropColumn(
                name: "SektorId",
                table: "ClanOrganizacije");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Sektor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_StudentId",
                table: "Sektor",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sektor_Student_StudentId",
                table: "Sektor",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
