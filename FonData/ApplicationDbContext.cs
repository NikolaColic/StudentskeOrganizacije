using FonData.Models;
using FonData.Models.AsocijativneKlase;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;

namespace FonData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentskaOrganizacija> StudentskaOrganizacija { get; set; }
        public DbSet<DrustvenaMreza> DrustvenaMreza { get; set; }
        public DbSet<ClanOrganizacije> ClanOrganizacije { get; set; }
        public DbSet<DrustveneOrganizacija> DrustveneOrganizacija { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<Obavestenje> Obavestenje { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Projekat> Projekat { get; set; }
        public DbSet<Sektor> Sektor { get; set; }
        public DbSet<Slika> Slika { get; set; }
        public DbSet<OrganizacijaInfo> OrganizacijaInfo { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region TableSplitting
            modelBuilder.Entity<OrganizacijaInfo>(dob =>
            {
                dob.ToTable("StudentskaOrganizacija");
            });

            modelBuilder.Entity<StudentskaOrganizacija>(ob =>
            {
                ob.ToTable("StudentskaOrganizacija");
                ob.HasOne(o => o.OrganizacijaInfo).WithOne()
                    .HasForeignKey<OrganizacijaInfo>(o => o.Id);
            });

            #endregion
        }
    }

}
