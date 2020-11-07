﻿// <auto-generated />
using System;
using FonData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FonData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200725153645_UpdateStudent")]
    partial class UpdateStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.ClanOrganizacije", b =>
                {
                    b.Property<int>("ClanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SektorId");

                    b.Property<int>("StudentId");

                    b.Property<int>("StudentskaOrganizacijaId");

                    b.HasKey("ClanId");

                    b.HasIndex("SektorId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentskaOrganizacijaId");

                    b.ToTable("ClanOrganizacije");
                });

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.DrustveneOrganizacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrustvenaMrezaMrezaId");

                    b.Property<int>("StudentskaOrganizacijaId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("DrustvenaMrezaMrezaId");

                    b.HasIndex("StudentskaOrganizacijaId");

                    b.ToTable("DrustveneOrganizacija");
                });

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.Subscribe", b =>
                {
                    b.Property<int>("SubscribeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StudentId");

                    b.Property<int>("StudentskaOrganizacijaId");

                    b.HasKey("SubscribeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentskaOrganizacijaId");

                    b.ToTable("Subscribe");
                });

            modelBuilder.Entity("FonData.Models.DrustvenaMreza", b =>
                {
                    b.Property<int>("MrezaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivMreze")
                        .IsRequired();

                    b.HasKey("MrezaId");

                    b.ToTable("DrustvenaMreza");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Obavestenje", b =>
                {
                    b.Property<int>("ObavestenjeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("Id");

                    b.Property<int?>("MrezaId");

                    b.Property<string>("NazivObavestenja");

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.HasKey("ObavestenjeId");

                    b.HasIndex("Id");

                    b.HasIndex("MrezaId");

                    b.ToTable("Obavestenje");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.OrganizacijaInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Istorija");

                    b.Property<string>("Misija");

                    b.Property<string>("Napomena");

                    b.Property<string>("ProjektiOpste");

                    b.Property<string>("Vizija");

                    b.HasKey("Id");

                    b.ToTable("StudentskaOrganizacija");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("Id");

                    b.Property<string>("Naslov")
                        .IsRequired();

                    b.Property<string>("Sadrzaj")
                        .IsRequired();

                    b.HasKey("PostId");

                    b.HasIndex("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Projekat", b =>
                {
                    b.Property<int>("ProjekatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id");

                    b.Property<string>("NazivProjekta")
                        .IsRequired();

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.Property<string>("PeriodOdrzavanja");

                    b.Property<string>("UrlProjekta");

                    b.HasKey("ProjekatId");

                    b.HasIndex("Id");

                    b.ToTable("Projekat");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Sektor", b =>
                {
                    b.Property<int>("SektorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivSektora")
                        .IsRequired();

                    b.Property<string>("OpisSektora");

                    b.HasKey("SektorId");

                    b.ToTable("Sektor");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Slika", b =>
                {
                    b.Property<int>("SlikaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id");

                    b.Property<string>("Namena")
                        .IsRequired();

                    b.Property<string>("Napomena");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("SlikaId");

                    b.HasIndex("Id");

                    b.ToTable("Slika");
                });

            modelBuilder.Entity("FonData.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Administrator");

                    b.Property<string>("Biografija");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("GodinaStudija");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<string>("InstagramUrl");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.Property<string>("Role");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("FonData.Models.StudentskaOrganizacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NazivOrganizacije")
                        .IsRequired();

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.Property<int?>("StudentId");

                    b.Property<string>("UrlSajta")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentskaOrganizacija");
                });

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.ClanOrganizacije", b =>
                {
                    b.HasOne("FonData.Models.SlabeKlase.Sektor", "Sektor")
                        .WithMany()
                        .HasForeignKey("SektorId");

                    b.HasOne("FonData.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("StudentskaOrganizacijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.DrustveneOrganizacija", b =>
                {
                    b.HasOne("FonData.Models.DrustvenaMreza", "DrustvenaMreza")
                        .WithMany()
                        .HasForeignKey("DrustvenaMrezaMrezaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("StudentskaOrganizacijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FonData.Models.AsocijativneKlase.Subscribe", b =>
                {
                    b.HasOne("FonData.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("StudentskaOrganizacijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Obavestenje", b =>
                {
                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("FonData.Models.DrustvenaMreza", "DrustvenaMreza")
                        .WithMany()
                        .HasForeignKey("MrezaId");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.OrganizacijaInfo", b =>
                {
                    b.HasOne("FonData.Models.StudentskaOrganizacija")
                        .WithOne("OrganizacijaInfo")
                        .HasForeignKey("FonData.Models.SlabeKlase.OrganizacijaInfo", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Post", b =>
                {
                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Projekat", b =>
                {
                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("FonData.Models.SlabeKlase.Slika", b =>
                {
                    b.HasOne("FonData.Models.StudentskaOrganizacija", "StudentskaOrganizacija")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("FonData.Models.StudentskaOrganizacija", b =>
                {
                    b.HasOne("FonData.Models.Student", "Predsednik")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}