using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonService.Service
{
    public class LibraryProjekat : ILibraryProjekat
    {
        private readonly ApplicationDbContext _db;

        public LibraryProjekat(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Projekat> VratiProjekte()
        {
            try
            {
                var projekti = _db.Projekat
                           .Include(p => p.StudentskaOrganizacija);
                           
                return projekti;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
