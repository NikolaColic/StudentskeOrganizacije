using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FonService.Service
{
    public class LibraryProjekat : ILibraryProjekat
    {
        private readonly ApplicationDbContext _db;

        public LibraryProjekat(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Projekat>> VratiProjekte()
        {
            try
            {
                var projekti = await _db.Projekat
                           .Include(p => p.StudentskaOrganizacija)
                           .ToListAsync();
                           
                return projekti;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
