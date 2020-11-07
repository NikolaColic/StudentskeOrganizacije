using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FonService.Service
{
    public class LibraryObavestenje : ILibraryObavestenje
    {
        private readonly ApplicationDbContext _db;

        public LibraryObavestenje(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Obavestenje> VratiObavestenja()
        {
            try
            {
                var obavestenja = _db.Obavestenje

                        .Include((o) => o.StudentskaOrganizacija)
                        .Include((o) => o.DrustvenaMreza)
                        .OrderByDescending((o) => o.Datum);
                 return obavestenja;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
