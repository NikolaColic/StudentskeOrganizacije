using FonData;
using FonData.Interface;
using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonService.Service
{
    public class LibrarySubscribe : ILibrarySubscribe
    {
        private readonly ApplicationDbContext _db;


        public LibrarySubscribe(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddSubscribe(SubscribeCreate subscribe)
        {
            try
            {
                Subscribe s = KreirajSubscribe(subscribe);
                if (s.Student is null || s.StudentskaOrganizacija is null) return false;
                await _db.AddAsync(s);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSubscribe(Subscribe s)
        {
            try
            {
                var subscribe = await VratiSubscribeId(s.SubscribeId);
                if (subscribe is null) return false;
                _db.Entry(subscribe).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
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

        public async Task<bool> UpdateSubscribe(int id, SubscribeCreate subscribe)
        {
            try
            {
                Subscribe s = KreirajSubscribe(subscribe);
                var staraVrednost = await VratiSubscribeId(id);
                if (staraVrednost is null) return false;
                s.SubscribeId = id;
                _db.Entry(staraVrednost).CurrentValues.SetValues(s);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<Subscribe> VratiSubscribeId(int id)
        {
            try
            {
                var sub = await _db.Subscribe.SingleOrDefaultAsync((su) => su.SubscribeId == id);
                return sub;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Subscribe>> GetSubscribe()
        {
            try
            {
                var subscribe = await _db.Subscribe
                        .Include(s => s.Student)
                        .Include(s => s.StudentskaOrganizacija)
                        .ToListAsync();
                return subscribe;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
