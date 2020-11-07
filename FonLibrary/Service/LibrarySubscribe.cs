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
    public class LibrarySubscribe : ILibrarySubscribe
    {
        private readonly ApplicationDbContext _db;


        public LibrarySubscribe(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddSubscribe(SubscribeCreate subscribe)
        {
            try
            {
                Subscribe s = KreirajSubscribe(subscribe);
                if (s.Student is null || s.StudentskaOrganizacija is null) return false;
                _db.Add(s);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSubscribe(Subscribe s)
        {
            try
            {
                var subscribe = VratiSubscribeId(s.SubscribeId);
                if (subscribe is null) return false;
                _db.Entry(subscribe).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Subscribe KreirajSubscribe(SubscribeCreate subscribe)
        {
            Subscribe s = new Subscribe();
            var organizacija = _db.StudentskaOrganizacija.SingleOrDefault((org) => org.Id == subscribe.OrganizacijaId);
            var student = _db.Student.SingleOrDefault((stu) => stu.StudentId == subscribe.StudentId);
            
            s.StudentskaOrganizacija = organizacija;
            s.Student = student;
            return s;
        }

        public bool UpdateSubscribe(int id, SubscribeCreate subscribe)
        {
            try
            {
                Subscribe s = KreirajSubscribe(subscribe);
                var staraVrednost = VratiSubscribeId(id);
                if (staraVrednost is null) return false;
                s.SubscribeId = id;
                _db.Entry(staraVrednost).CurrentValues.SetValues(s);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Subscribe VratiSubscribeId(int id)
        {
            try
            {
                var sub = _db.Subscribe.SingleOrDefault((su) => su.SubscribeId == id);
                return sub;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Subscribe> GetSubscribe()
        {
            try
            {
                var subscribe = _db.Subscribe
                        .Include(s => s.Student)
                        .Include(s => s.StudentskaOrganizacija);
                return subscribe;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
