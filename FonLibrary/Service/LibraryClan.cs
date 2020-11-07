using FonData;
using FonData.Interface;
using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FonService.Service
{
    public class LibraryClan : ILibraryClan
    {
        private readonly ApplicationDbContext _db;


        public LibraryClan(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool DodajClana(SubscribeCreate cl )
        {
            try
            {
                var clan = KreirajClan(cl);
                if (clan.Student is null || clan.StudentskaOrganizacija is null || clan.Sektor is null) return false;
                _db.Add(clan);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private ClanOrganizacije KreirajClan(SubscribeCreate subscribe)
        {
            ClanOrganizacije s = new ClanOrganizacije();
            var organizacija = _db.StudentskaOrganizacija.SingleOrDefault((org) => org.Id == subscribe.OrganizacijaId);
            var student = _db.Student.SingleOrDefault((stu) => stu.StudentId == subscribe.StudentId);
            var sektor = _db.Sektor.SingleOrDefault((sek) => sek.SektorId == subscribe.SektorId);    
            s.StudentskaOrganizacija = organizacija;
            s.Student = student;
            s.Sektor = sektor;
            return s;
        }

        public bool DeleteClan(int id)
        {
            try
            {
                var clan = _db.ClanOrganizacije.SingleOrDefault((sub) => sub.ClanId == id);
                if (clan is null) return false;
                _db.Entry(clan).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ClanOrganizacije> VratiClanove()
        {
            try
            {
                var clanovi = _db.ClanOrganizacije
                        .Include(s => s.Student)
                        .Include(s => s.StudentskaOrganizacija)
                        .Include(s => s.Sektor);

                return clanovi;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
