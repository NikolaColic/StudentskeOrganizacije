using FonData;
using FonData.Interface;
using FonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FonService.Service
{
    public class LibraryDrustveneMreze : ILibraryDrustveneMreze
    {
        private readonly ApplicationDbContext _db;


        public LibraryDrustveneMreze(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<DrustvenaMreza> VratiDrustveneMreze()
        {
            try
            {
                var drustveneMreze = _db.DrustvenaMreza;
                return drustveneMreze;
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        public DrustvenaMreza VratiMrezuId(int? id)
        {
            try
            {
                var mreza = _db.DrustvenaMreza.SingleOrDefault((mre) => mre.MrezaId == id);
                return mreza;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
