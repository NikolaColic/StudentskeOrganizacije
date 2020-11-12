using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FonService.Service
{
    public class LibrarySektor : ILibrarySektor
    {
        private readonly ApplicationDbContext _db;

        public LibrarySektor(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Sektor>> VratiSektore()
        {
            try
            {
                var sektori = await _db.Sektor.ToListAsync();
                return sektori;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
