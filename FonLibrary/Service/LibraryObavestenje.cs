using FonData;
using FonData.Interface;
using FonData.Models.SlabeKlase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonService.Service
{
    public class LibraryObavestenje : ILibraryObavestenje
    {
        private readonly ApplicationDbContext _db;

        public LibraryObavestenje(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Obavestenje>> VratiObavestenja()
        {
            try
            {
                var obavestenja = await _db.Obavestenje
                        .Include((o) => o.StudentskaOrganizacija)
                        .Include((o) => o.DrustvenaMreza)
                        .OrderByDescending((o) => o.Datum)
                        .ToListAsync();
                 return obavestenja;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class TaskIEnumerable<T>
    {
    }
}
