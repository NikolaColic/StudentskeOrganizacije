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
    public class LibraryPost : ILibraryPost
    {
        private readonly ApplicationDbContext _db;

        public LibraryPost(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Post> VratiPostove()
        {
            try
            {
                var postovi = _db.Post
                        .Include(p => p.StudentskaOrganizacija)
                        .OrderByDescending((p) => p.Datum);
                return postovi;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
