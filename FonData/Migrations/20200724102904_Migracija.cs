using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FonData.Migrations
{
    public partial class Migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrustvenaMreza",
                columns: table => new
                {
                    MrezaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivMreze = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrustvenaMreza", x => x.MrezaId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    InstagramUrl = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    GodinaStudija = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    Administrator = table.Column<bool>(nullable: false),
                    Biografija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Sektor",
                columns: table => new
                {
                    SektorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivSektora = table.Column<string>(nullable: false),
                    OpisSektora = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektor", x => x.SektorId);
                    table.ForeignKey(
                        name: "FK_Sektor_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentskaOrganizacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivOrganizacije = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UrlSajta = table.Column<string>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    Misija = table.Column<string>(nullable: true),
                    Vizija = table.Column<string>(nullable: true),
                    Istorija = table.Column<string>(nullable: true),
                    ProjektiOpste = table.Column<string>(nullable: true),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentskaOrganizacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentskaOrganizacija_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClanOrganizacije",
                columns: table => new
                {
                    ClanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StudentskaOrganizacijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanOrganizacije", x => x.ClanId);
                    table.ForeignKey(
                        name: "FK_ClanOrganizacije_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanOrganizacije_StudentskaOrganizacija_StudentskaOrganizacijaId",
                        column: x => x.StudentskaOrganizacijaId,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrustveneOrganizacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrustvenaMrezaMrezaId = table.Column<int>(nullable: false),
                    StudentskaOrganizacijaId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrustveneOrganizacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrustveneOrganizacija_DrustvenaMreza_DrustvenaMrezaMrezaId",
                        column: x => x.DrustvenaMrezaMrezaId,
                        principalTable: "DrustvenaMreza",
                        principalColumn: "MrezaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrustveneOrganizacija_StudentskaOrganizacija_StudentskaOrganizacijaId",
                        column: x => x.StudentskaOrganizacijaId,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavestenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    ObavestenjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    NazivObavestenja = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: false),
                    MrezaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavestenje", x => x.ObavestenjeId);
                    table.ForeignKey(
                        name: "FK_Obavestenje_StudentskaOrganizacija_Id",
                        column: x => x.Id,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obavestenje_DrustvenaMreza_MrezaId",
                        column: x => x.MrezaId,
                        principalTable: "DrustvenaMreza",
                        principalColumn: "MrezaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Naslov = table.Column<string>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_StudentskaOrganizacija_Id",
                        column: x => x.Id,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projekat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    ProjekatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivProjekta = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    UrlProjekta = table.Column<string>(nullable: true),
                    PeriodOdrzavanja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekat", x => x.ProjekatId);
                    table.ForeignKey(
                        name: "FK_Projekat_StudentskaOrganizacija_Id",
                        column: x => x.Id,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    SlikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: false),
                    Namena = table.Column<string>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.SlikaId);
                    table.ForeignKey(
                        name: "FK_Slika_StudentskaOrganizacija_Id",
                        column: x => x.Id,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                columns: table => new
                {
                    SubscribeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StudentskaOrganizacijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.SubscribeId);
                    table.ForeignKey(
                        name: "FK_Subscribe_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscribe_StudentskaOrganizacija_StudentskaOrganizacijaId",
                        column: x => x.StudentskaOrganizacijaId,
                        principalTable: "StudentskaOrganizacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanOrganizacije_StudentId",
                table: "ClanOrganizacije",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClanOrganizacije_StudentskaOrganizacijaId",
                table: "ClanOrganizacije",
                column: "StudentskaOrganizacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_DrustveneOrganizacija_DrustvenaMrezaMrezaId",
                table: "DrustveneOrganizacija",
                column: "DrustvenaMrezaMrezaId");

            migrationBuilder.CreateIndex(
                name: "IX_DrustveneOrganizacija_StudentskaOrganizacijaId",
                table: "DrustveneOrganizacija",
                column: "StudentskaOrganizacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavestenje_Id",
                table: "Obavestenje",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Obavestenje_MrezaId",
                table: "Obavestenje",
                column: "MrezaId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Id",
                table: "Post",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projekat_Id",
                table: "Projekat",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sektor_StudentId",
                table: "Sektor",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Slika_Id",
                table: "Slika",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskaOrganizacija_StudentId",
                table: "StudentskaOrganizacija",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_StudentId",
                table: "Subscribe",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_StudentskaOrganizacijaId",
                table: "Subscribe",
                column: "StudentskaOrganizacijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanOrganizacije");

            migrationBuilder.DropTable(
                name: "DrustveneOrganizacija");

            migrationBuilder.DropTable(
                name: "Obavestenje");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Projekat");

            migrationBuilder.DropTable(
                name: "Sektor");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "Subscribe");

            migrationBuilder.DropTable(
                name: "DrustvenaMreza");

            migrationBuilder.DropTable(
                name: "StudentskaOrganizacija");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
