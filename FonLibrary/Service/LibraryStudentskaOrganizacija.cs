using FonData;
using FonData.Interface;
using FonData.Models;
using FonData.Models.AsocijativneKlase;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FonService.Service
{
    public class LibraryStudentskaOrganizacija : ILibraryStudentskaOrganizacija
    {
        private readonly ApplicationDbContext _db;

        public LibraryStudentskaOrganizacija(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddStudentskuOrganizaciju(StudentskaOrganizacija organizacija)
        {
            try
            {
                var predsednik = VratiPredsednika(organizacija.Predsednik.StudentId);
                if (predsednik is null) return false;
                organizacija.Predsednik = predsednik;
                _db.Add(organizacija);
                _db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteStudentskuOrganizaciju(int id)
        {
            try
            {
                var org = VratiOrganizacijuId(id);
                if (org is null) return false;
                _db.Entry(org).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool UpdateStudentskuOrganizaciju(int id, StudentskaOrganizacija organizacija)
        {
            try
            {
                var org = VratiOrganizacijuId(id);
                if (org is null) return false;

                var predsednik = VratiPredsednika(organizacija.Predsednik.StudentId);
                if (predsednik is null) return false;
                organizacija.Predsednik = predsednik;
                organizacija.Id = id;
                _db.Entry(org).CurrentValues.SetValues(organizacija);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Student VratiPredsednika(int id)
        {
            try
            {
                var predsednik = _db.Student.SingleOrDefault((student) => student.StudentId == id);
                return predsednik;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Student> VratiClanoveOrganizacije(int id)
        {
            try
            {
                var clanovi = _db.ClanOrganizacije
                    .Where((clan) => clan.StudentskaOrganizacija.Id == id)
                    .Select((clan) => clan.Student);
                return clanovi;
            }
            catch (Exception)
            {
                return null;
            }
                
        }

        public IEnumerable<StudentskaOrganizacija> GetOrganizacije()
        {
            try
            {
                var organizacije = _db.StudentskaOrganizacija
                        .Include((org) => org.Predsednik);

                return organizacije;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public StudentskaOrganizacija VratiOrganizacijuId(int? id)
        {
            try
            {
                return _db.StudentskaOrganizacija
                       .Include((st) => st.Predsednik)
                       .SingleOrDefault((orga) => orga.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        //Subscribe
        public IEnumerable<Student> VratiSubscribeOrganizacije(int id)
        {
            try
            {
                var subscribe = _db.Subscribe
                    .Where((clan) => clan.StudentskaOrganizacija.Id == id)
                    .Select((clan) => clan.Student);
                return subscribe;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Drustvena Mreza

        public IEnumerable<DrustveneOrganizacija> VratiUrlMreza(int id)
        {
            try
            {
                var mreze = _db.DrustveneOrganizacija
                    .Include((mreza)=> mreza.StudentskaOrganizacija)
                    .Include((mreza)=> mreza.DrustvenaMreza)
                    .Where((clan) => clan.StudentskaOrganizacija.Id == id);
                    
                return mreze;
            }
            catch (Exception)
            {
                return null;
            }

        }
        
        
        //Obavestenja 

        public bool DodajObavestenje(Obavestenje obavestenje)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(obavestenje.StudentskaOrganizacija.Id);
                if (organizacija is null) return false;
                DrustvenaMreza mreza = null;
                if (!(obavestenje.DrustvenaMreza is null))
                {
                   mreza = _db.DrustvenaMreza.SingleOrDefault((dr) => dr.MrezaId == obavestenje.DrustvenaMreza.MrezaId);

                }
                if (mreza is null) return false;
                obavestenje.DrustvenaMreza = mreza;
                obavestenje.StudentskaOrganizacija = organizacija;
                _db.Add(obavestenje);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateObavestenje(int id, Obavestenje obavestenje)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(id);
                if (organizacija is null) return false;
                obavestenje.StudentskaOrganizacija = organizacija;
                var staroObavestenje = _db.Obavestenje.SingleOrDefault((obav) => obav.ObavestenjeId == obavestenje.ObavestenjeId
                && obav.StudentskaOrganizacija.Id == organizacija.Id);
                if (staroObavestenje is null) return false;
                _db.Entry(staroObavestenje).CurrentValues.SetValues(obavestenje);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ObrisiObavestenje(Obavestenje o)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(o.StudentskaOrganizacija.Id);
                if (organizacija is null) return false;
                var kalendar = _db.Obavestenje.SingleOrDefault((obav) => obav.ObavestenjeId == o.ObavestenjeId
                && obav.StudentskaOrganizacija.Id == organizacija.Id);
                if (kalendar is null) return false;
                _db.Entry(kalendar).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Obavestenje> VratiObavestenja(int id)
        {
            try
            {
                var obavestenja = _db.Obavestenje
                        .Include((o) => o.StudentskaOrganizacija)
                        .Include((o) => o.StudentskaOrganizacija.Predsednik)
                        .Include((o)=> o.DrustvenaMreza)
                        .Where((o) => o.StudentskaOrganizacija.Id == id);
                return obavestenja;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Post 

        public IEnumerable<Post> VratiPostove(int id)
        {
            try
            {
                var postovi = _db.Post
                        .Include(p => p.StudentskaOrganizacija)
                        .Include(p => p.StudentskaOrganizacija.Predsednik)
                        .Where(p => p.StudentskaOrganizacija.Id == id)
                        .OrderByDescending(org => org.Datum);
                return postovi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DodajPost(Post post)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(post.StudentskaOrganizacija.Id);
                if (organizacija is null) return false;
                post.StudentskaOrganizacija = organizacija;
                _db.Add(post);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                 return false;
            }
        }

        public bool UpdatePost(Post post)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(post.StudentskaOrganizacija.Id);
                if (organizacija is null) return false;

                post.StudentskaOrganizacija = organizacija;
                
                var stariPost = _db.Post.SingleOrDefault((poru) => poru.PostId == post.PostId
                && poru.StudentskaOrganizacija.Id == organizacija.Id);
                if (stariPost is null) return false;
                _db.Entry(stariPost).CurrentValues.SetValues(post);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePost(int organizacijaId, int postId)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(organizacijaId);
                if (organizacija is null) return false;
                var porukaDelete = _db.Post.SingleOrDefault((poru) => poru.PostId == postId
                && poru.StudentskaOrganizacija.Id == organizacija.Id);
                if (porukaDelete is null) return false;
                _db.Entry(porukaDelete).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Projekat

        public IEnumerable<Projekat> VratiProjekte(int id)
        {
            try
            {
                var projekti = _db.Projekat
                        .Include(p => p.StudentskaOrganizacija)
                        .Include(p => p.StudentskaOrganizacija.Predsednik)
                        .Where(p => p.StudentskaOrganizacija.Id == id);
                return projekti;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddProjekat(int id, Projekat projekat)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(id);
                if (organizacija is null) return false;
                projekat.StudentskaOrganizacija = organizacija;
                _db.Add(projekat);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProjekat(int id, Projekat projekat)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(id);
                if (organizacija is null) return false;

                projekat.StudentskaOrganizacija = organizacija;

                var stariProjekat = _db.Projekat.SingleOrDefault((pro) => pro.ProjekatId == projekat.ProjekatId &&
                pro.StudentskaOrganizacija.Id == id);
                if (stariProjekat is null) return false;
                _db.Entry(stariProjekat).CurrentValues.SetValues(projekat);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProjekat(int organizacijaId, int projekatId)
        {
            try
            {
                var organizacija = VratiOrganizacijuId(organizacijaId);
                if (organizacija is null) return false;
                var porukaDelete = _db.Projekat.SingleOrDefault(((poru) => poru.ProjekatId == projekatId
                && poru.StudentskaOrganizacija.Id == organizacija.Id));
                if (porukaDelete is null) return false;
                _db.Entry(porukaDelete).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public IEnumerable<Slika> VratiSlike(int id)
        {
            try
            {
                var slike = _db.Slika
                        .Include(p => p.StudentskaOrganizacija)
                        .Where(p => p.StudentskaOrganizacija.Id == id);
                return slike;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public OrganizacijaInfo VratiOrganizacijaInfo(int id)
        {

            try
            {
                var slike = _db.OrganizacijaInfo.SingleOrDefault((org)=> org.Id == id);
                
                return slike;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
