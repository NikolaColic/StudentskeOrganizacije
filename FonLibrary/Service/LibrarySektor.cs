using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonService.Service
{
    public class LibrarySektor : ILibrarySektor
    {
        private readonly ApplicationDbContext _db;

        public LibrarySektor(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Sektor> VratiSektore()
        {
            try
            {
                var sektori = _db.Sektor;
                return sektori;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
