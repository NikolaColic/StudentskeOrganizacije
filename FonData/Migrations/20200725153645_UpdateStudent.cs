using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FonData.Migrations
{
    public partial class UpdateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Student",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                nullable: false,
                defaultValue: "");
        }
    }
}
