using FonData;
using FonData.Interface;
using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Threading.Tasks;

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
                var clanTask = Task.Run(async() =>
                {
                    var clan = await KreirajClan(cl);
                    return clan;
                });
                var clanP = clanTask.ContinueWith((t) =>
                {
                    var clan = (ClanOrganizacije)t.Result;
                    if (clan.Student is null || clan.StudentskaOrganizacija is null || clan.Sektor is null) throw new Exception();
                    return clan;
                });
                var rez = clanTask.ContinueWith((t) =>
                {
                    try
                    {
                        _db.Add(t.Result);
                        _db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }, TaskContinuationOptions.OnlyOnCanceled);

                rez = clanTask.ContinueWith((t) =>
                {
                    return false;
                }, TaskContinuationOptions.OnlyOnFaulted);

                return rez.Result;
               
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<ClanOrganizacije> KreirajClan(SubscribeCreate subscribe)
        {
            var rez = Task.Run(async () =>
            {
                ClanOrganizacije s = new ClanOrganizacije();
                var organizacija = await _db.StudentskaOrganizacija.SingleOrDefaultAsync((org) => org.Id == subscribe.OrganizacijaId);
                var student = await _db.Student.SingleOrDefaultAsync((stu) => stu.StudentId == subscribe.StudentId);
                var sektor = await _db.Sektor.SingleOrDefaultAsync((sek) => sek.SektorId == subscribe.SektorId);
                s.StudentskaOrganizacija = organizacija;
                s.Student = student;
                s.Sektor = sektor;
                return s;
            });
            var greska = rez.ContinueWith((t) =>
            {
                return false;
            }, TaskContinuationOptions.OnlyOnFaulted);
            if (!greska.Result) return null;
            return rez.Result;

        }

        public async Task<bool> DeleteClan(int id)
        {
            try
            {
                var clan = await _db.ClanOrganizacije.SingleOrDefaultAsync((sub) => sub.ClanId == id);
                if (clan is null) return false;
                _db.Entry(clan).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async  Task<IEnumerable<ClanOrganizacije>> VratiClanove()
        {
            var clanovi = new List<ClanOrganizacije>();
            await Task.Run(async () =>
            {
                try
                {
                    clanovi = await _db.ClanOrganizacije
                                   .Include(s => s.Student)
                                   .Include(s => s.StudentskaOrganizacija)
                                   .Include(s => s.Sektor)
                                   .ToListAsync();
                    
                }
                catch (Exception)
                {
                    clanovi = null;
                }
            });
            return clanovi;   
        }
    }
}
